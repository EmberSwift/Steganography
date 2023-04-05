using System;
using System.Drawing;
using System.IO;

namespace Stega
{
    class Picture
    {
        string Read()
        {
            string text = "";
            string line ="";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"C:\Users\Oswin\Desktop\Ужас человечества\4 курс\1 трим\КМЗИ\Lab6\input.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    text += line;
                    //write the line to console window
                    //Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return text;
        }
        void GetPicture()
        {
            try
            {
                // Retrieve the image.
                var image1 = new Bitmap(@"C:\Users\Oswin\Desktop\Ужас человечества\4 курс\1 трим\КМЗИ\Lab6\CoVa.bmp");
                string text = Read();
                int count = 0;
                int x, y;

                if (text != "")
                    // Loop through the images pixels to reset color.
                    for (x = 0; x < image1.Width; x++)
                    {
                        for (y = 0; y < image1.Height; y++)
                        {
                            if (count < text.Length)
                            {
                                byte one = Convert.ToByte((text[count]%256) & 3);
                                byte two = Convert.ToByte(((text[count] % 256) >> 2) & 3);
                                byte three = Convert.ToByte(((text[count] % 256) >> 4) & 3);
                                byte four = Convert.ToByte(((text[count] % 256) >> 6) & 3);

                                Color pixelColor = image1.GetPixel(x, y);
                                byte newB = (byte)((pixelColor.B >> 2) * 4 | one);
                                Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, newB);
                                image1.SetPixel(x, y, newColor);
                                y++;

                                pixelColor = image1.GetPixel(x, y);
                                newB = (byte)((pixelColor.B >> 2) * 4 | two);
                                newColor = Color.FromArgb(pixelColor.R, pixelColor.G, newB);
                                image1.SetPixel(x, y, newColor);
                                y++;

                                pixelColor = image1.GetPixel(x, y);
                                newB = (byte)((pixelColor.B >> 2) * 4 | three);
                                newColor = Color.FromArgb(pixelColor.R, pixelColor.G, newB);
                                image1.SetPixel(x, y, newColor);
                                y++;

                                pixelColor = image1.GetPixel(x, y);
                                newB = (byte)((pixelColor.B >> 2) * 4 | four);
                                newColor = Color.FromArgb(pixelColor.R, pixelColor.G, newB);
                                image1.SetPixel(x, y, newColor);
                                y++;

                                count++;
                            }
                            //Console.WriteLine(pixelColor.R + "\n" + r);
                        }
                    }

                image1.Save(@"C:\Users\Oswin\Desktop\Ужас человечества\4 курс\1 трим\КМЗИ\Lab6\CoVa2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                //Console.WriteLine(text);

                string encText = "";
                count = 0;

                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        if (count < text.Length)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            int temp = pixelColor.B & 3;
                            y++;

                            pixelColor = image1.GetPixel(x, y);
                            temp = temp | ((pixelColor.B & 3) << 2);
                            y++;

                            pixelColor = image1.GetPixel(x, y);
                            temp = temp | ((pixelColor.B & 3) << 4);
                            y++;

                            pixelColor = image1.GetPixel(x, y);
                            temp = temp | ((pixelColor.B & 3) << 6);
                            y++;

                            encText += (char)(temp);

                            count++;
                        }
                        //Console.WriteLine(pixelColor.R + "\n" + r);
                    }
                }

                Console.WriteLine(encText);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("There was an error." +
                     "Check the path to the image file.");
            }
        }

        void GetPicture1()
        {
            try
            {
                // Retrieve the image.
                var image1 = new Bitmap(@"C:\Users\Oswin\Desktop\Ужас человечества\4 курс\1 трим\КМЗИ\Lab6\CoVa.bmp");
                string text = Read();
                int count = 0;
                int x, y;

                if (text != "")
                    // Loop through the images pixels to reset color.
                    for (x = 0; x < image1.Width; x++)
                    {
                        for (y = 0; y < image1.Height; y++)
                        {
                            if (count < text.Length)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, text[count] % 256);
                                image1.SetPixel(x, y, newColor);
                                count++;
                            }
                            //Console.WriteLine(pixelColor.R + "\n" + r);
                        }
                    }

                image1.Save(@"C:\Users\Oswin\Desktop\Ужас человечества\4 курс\1 трим\КМЗИ\Lab6\CoVa2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

               // Console.WriteLine(text);

                string encText = "";
                count = 0;

                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        if (count < text.Length)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            encText += (char)(pixelColor.B);

                            count++;
                        }
                        //Console.WriteLine(pixelColor.R + "\n" + r);
                    }
                }

                Console.WriteLine(encText);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("There was an error." +
                     "Check the path to the image file.");
            }
        }


        public Picture()
        {
            GetPicture();
        }
    }
    class Program
    {
        static void Main()
        {
            Picture picture = new Picture();
        }
    }
}



/*
 
 */