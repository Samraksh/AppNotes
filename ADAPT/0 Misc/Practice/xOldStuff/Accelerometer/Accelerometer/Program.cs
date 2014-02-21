using System;   // *** need reference
using Microsoft.SPOT;
	


namespace Graphics {
    public class Program {
        private static
        Samraksh.SPOT.Hardware.Accelerometer accel; // the accelerometer object

        public static void Main() {
            Int16 xVal, yVal;		// x & y axis values
            int rotation;   // create display bitmap
            
            Bitmap LCD = new Bitmap(200, 142);
            Bitmap image = new Bitmap(Resources.GetBytes(Resources.BinaryResources.logo),Bitmap.BitmapImageType.Bmp); // import bitmap from resource to display

            // Initialize the accelerometer
            accel = new Samraksh.SPOT.Hardware.Accelerometer();
            accel.ADAPT_Accel_Init();

            while (true) {		// rotate the image forever
                // get the x & y accelerometer values
                xVal = accel.ADAPT_Accel_GetX();
                yVal = accel.ADAPT_Accel_GetY();

                // determine simple rotation
                if (xVal > 12000) rotation = 0;
                else if (xVal < -12000) rotation = 100;
                else if (yVal > 12000) rotation = 270;
                else rotation = 90;

                LCD.Clear();		// Clear the bitmap
                LCD.RotateImage(rotation, 0, 0, image, 0, 0, image.Width, image.Height, 0xff);	// rotate the image
                LCD.Flush();		// draw image to screen
            }
        }
    }
}
