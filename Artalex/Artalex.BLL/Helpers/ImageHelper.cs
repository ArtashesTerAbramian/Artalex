// using SixLabors.ImageSharp;
// using SixLabors.ImageSharp.Formats.Jpeg;
// using SixLabors.ImageSharp.Processing;

// namespace JustTry.BLL.Helpers
// {
    // public static class ImageHelper
    // {
        // public static string Resize(string imageBase64, int factor)
        // {
            // var bytes = Convert.FromBase64String(imageBase64);

            // using (Image image = Image.Load(bytes))
            // {
                // int width = image.Width / factor;
                // int height = image.Height / factor;
                // image.Mutate(x => x.Resize(width, height));

                // var resultBase64 = image.ToBase64String(JpegFormat.Instance);
                // return resultBase64.Substring(resultBase64.IndexOf(",") + 1);
            // }
        // }
    // }
// }
