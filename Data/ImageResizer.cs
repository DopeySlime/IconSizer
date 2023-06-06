using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

using System.IO.Compression;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace IconSize.Data
{
    public class ImageResizer
    {
        private readonly List<Size> _sizes;

        public ImageResizer(List<Size> sizes)
        {
            this._sizes = sizes;
        }

        private static async Task SaveResizedImageAsync(MemoryStream image, string filePath)
        {
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(fileStream);
        }

        public async Task<MemoryStream> ResizeImage(IBrowserFile file)
        {
            var result = new MemoryStream();
            
            await using var stream = file.OpenReadStream();
            using var image = await Image.LoadAsync(stream);
            
            using var archive = new ZipArchive(result, ZipArchiveMode.Create, true);


            foreach (var size in _sizes)
            {
                var width = Convert.ToInt32(size.HW);
                var height = Convert.ToInt32(size.HW);
                var dpi = size.DpiName;

                using var resizedStream = new MemoryStream();
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new SixLabors.ImageSharp.Size(width, height),
                    Mode = ResizeMode.Stretch,
                    Sampler = KnownResamplers.Lanczos3,
                    Compand = false,
                    Position = AnchorPositionMode.Center
                }));
                var encoder = new JpegEncoder { Quality = 90 };
                await image.SaveAsync(resizedStream, encoder);
                resizedStream.Seek(0, SeekOrigin.Begin);
                
                var fileExtension = ".jpg";
                var fileNameBuilder = new StringBuilder();
                fileNameBuilder.Append($"{width}x{height}_{size.Platform}");
                if (!string.IsNullOrWhiteSpace(size.Role))
                {
                    fileNameBuilder.Append($"_{size.Role}");
                }
                if (!string.IsNullOrWhiteSpace(size.Subtype))
                {
                    fileNameBuilder.Append($"_{size.Subtype}");
                }
                fileNameBuilder.Append($"{fileExtension}");
                var entryName = fileNameBuilder.ToString();
                await SaveResizedImageAsync(resizedStream, $"out/{entryName}");
                Console.WriteLine(entryName);
                var entry = archive.CreateEntry(entryName);
                
                await using var entryStream = entry.Open();
                await resizedStream.CopyToAsync(entryStream);
            }

            result.Seek(0, SeekOrigin.Begin);
            return result;
        }
    }
}
