using CineMaxColDal.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CineMaxColBLL.Services
{
    public class CloudinaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CloudinaryService(IUnitOfWork IUnitOfWork)
        {
            _unitOfWork = IUnitOfWork;
        }


        // FUNCION PARA SUBIR O ACTUALIZAR UNA FOTO DIRECTAMENTE EN CLOUDINARY
        public async Task<string?> SubirFoto(string? nombreFoto, Stream stream, string? tipo, string? Folder)
        {
            string? resultado = "";
            var config = await _unitOfWork.CloudinaryR.TraerCredenciales();
            var cloudinary = new Cloudinary(new Account(config?.CloudName, config?.ApiKey, config?.ApiSecret));
            string? folder = "";

            // SEGUN EL FOLDER (NOMBRE DE LA CATEGORIA), SE ASIGNA A LA DIRECCIÓN DEL FOLDER PARA CLOUDINARY
            switch (tipo)
            {
                case "ComidaGeneral":
                    folder = $"CineMaxCOL/Comidas/Categorias/{Folder}";
                    break;
                case "Categorias":
                    folder = $"CineMaxCOL/Comidas/Categorias/{Folder}/Thumbnail";
                    break;
                default:
                    break;
            }
            var uploadParams = new ImageUploadParams // Parametros para subir la foto a cloudinary
            {
                File = new FileDescription(nombreFoto, stream),
                Overwrite = true,
                Folder = folder
            };
            var result = await cloudinary.UploadAsync(uploadParams);
            return resultado = result.SecureUrl?.ToString();
        }
    }
}