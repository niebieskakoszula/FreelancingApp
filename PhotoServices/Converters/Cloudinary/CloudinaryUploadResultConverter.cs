using CloudinaryDotNet.Actions;
using System.ComponentModel;
using System.Globalization;

namespace PhotoServices.Converters.Cloudinary
{
    public class CloudinaryUploadResultConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(UploadResult);
        }
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var uploadResult = (value as UploadResult) ?? throw new ArgumentNullException();
            if (uploadResult.GetType() != typeof(UploadResult))
            {
                throw new NotSupportedException("Invalid type");
            }
            
            switch (uploadResult.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return ResultEnums.UploadResult.Success;
                case System.Net.HttpStatusCode.BadRequest:
                    return ResultEnums.UploadResult.InvalidFile;
                case System.Net.HttpStatusCode.NotFound:
                    return ResultEnums.UploadResult.InvalidUrl;
                case System.Net.HttpStatusCode.RequestTimeout:
                    return ResultEnums.UploadResult.TimeOut;
                default:
                    return ResultEnums.UploadResult.Failure;
            }
        }
    }
}
