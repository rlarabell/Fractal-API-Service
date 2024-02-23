using System.Runtime.InteropServices;

namespace Fractal_API_Service
{
    public static class FractalFabricator
    {
        [DllImport("Fractal Fabricator.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_pixel_data(int[] output_data, int width, int height);
    }
}
