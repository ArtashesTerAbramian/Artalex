using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace Artalex.BLL.Helpers
{
    // public class CustomPhysicalFileSystemProvider : IImageProvider
    // {
    //     /// <summary>
    //     /// The file provider abstraction.
    //     /// </summary>
    //     private readonly IFileProvider _fileProvider;
    //
    //     /// <summary>
    //     /// Contains various format helper methods based on the current configuration.
    //     /// </summary>
    //     private readonly FormatUtilities _formatUtilities;
    //
    //     /// <summary>
    //     /// Request base request path.
    //     /// </summary>
    //     private readonly PathString _requestPath;
    //
    //     /// <summary>
    //     /// A match function used by the resolver to identify itself as the correct resolver to use.
    //     /// </summary>
    //     private Func<HttpContext, bool> _match;
    //
    //     /// <summary>
    //     /// Initializes a new instance of the <see cref="PhysicalFileSystemProvider"/> class.
    //     /// </summary>
    //     /// <param name="environment">The environment used by this middleware.</param>
    //     /// <param name="formatUtilities">Contains various format helper methods based on the current configuration.</param>
    //     public CustomPhysicalFileSystemProvider(IWebHostEnvironment environment, FormatUtilities formatUtilities, IOptions<FileSettings> mediaOptions)
    //     {
    //         this._fileProvider = string.IsNullOrEmpty(mediaOptions.Value.FilePath) ? environment.WebRootFileProvider : new PhysicalFileProvider(mediaOptions.Value.FilePath);
    //         this._formatUtilities = formatUtilities;
    //
    //         this._requestPath = mediaOptions.Value.RequestPath;
    //     }
    //
    //     /// <inheritdoc/>
    //     public ProcessingBehavior ProcessingBehavior { get; } = ProcessingBehavior.All;
    //
    //     /// <inheritdoc/>
    //     public Func<HttpContext, bool> Match
    //     {
    //         get { return string.IsNullOrEmpty(_requestPath) ? _ => true : Match1 ?? IsMatch; }
    //
    //         set => Match1 = value;
    //     }
    //
    //     public Func<HttpContext, bool> Match1 { get => _match; set => _match = value; }
    //
    //     /// <inheritdoc/>
    //     public bool IsValidRequest(HttpContext context)
    //     {
    //         return _formatUtilities.TryGetExtensionFromUri(context.Request.GetDisplayUrl(), out _);
    //     }
    //
    //     /// <inheritdoc/>
    //     public Task<IImageResolver> GetAsync(HttpContext context)
    //     {
    //         string path = string.IsNullOrEmpty(_requestPath) ? context.Request.Path.Value : context.Request.Path.Value.Substring(_requestPath.Value.Length);
    //
    //         IFileInfo fileInfo = this._fileProvider.GetFileInfo(path);
    //
    //         if (!fileInfo.Exists)
    //         {
    //             return Task.FromResult<IImageResolver>(null);
    //         }
    //
    //         return Task.FromResult<IImageResolver>(new FileProviderImageResolver(fileInfo));
    //     }
    //
    //     private bool IsMatch(HttpContext context)
    //     {
    //         if (!context.Request.Path.StartsWithNormalizedSegments(_requestPath, StringComparison.OrdinalIgnoreCase))
    //         {
    //             return false;
    //         }
    //
    //         return true;
    //     }
    // }
    //
    // public static class PathStringExtensions
    // {
    //     public static bool StartsWithNormalizedSegments(this PathString path, PathString other)
    //     {
    //         if (other.HasValue && other.Value.EndsWith('/'))
    //         {
    //             return path.StartsWithSegments(other.Value.Substring(0, other.Value.Length - 1));
    //         }
    //
    //         return path.StartsWithSegments(other);
    //     }
    //
    //     public static bool StartsWithNormalizedSegments(this PathString path, PathString other, StringComparison comparisonType)
    //     {
    //         if (other.HasValue && other.Value.EndsWith('/'))
    //         {
    //             return path.StartsWithSegments(other.Value.Substring(0, other.Value.Length - 1), comparisonType);
    //         }
    //
    //         return path.StartsWithSegments(other, comparisonType);
    //     }
    //
    //     public static bool StartsWithNormalizedSegments(this PathString path, PathString other, out PathString remaining)
    //     {
    //         if (other.HasValue && other.Value.EndsWith('/'))
    //         {
    //             return path.StartsWithSegments(other.Value.Substring(0, other.Value.Length - 1), out remaining);
    //         }
    //
    //         return path.StartsWithSegments(other, out remaining);
    //     }
    //
    //     public static bool StartsWithNormalizedSegments(this PathString path, PathString other, StringComparison comparisonType, out PathString remaining)
    //     {
    //         if (other.HasValue && other.Value.EndsWith('/'))
    //         {
    //             return path.StartsWithSegments(other.Value.Substring(0, other.Value.Length - 1), comparisonType, out remaining);
    //         }
    //
    //         return path.StartsWithSegments(other, comparisonType, out remaining);
    //     }
    // }
}
