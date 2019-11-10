using SGEP_Model.Models;

namespace SGEP_Site.Models
{
    public class ModelConverterMaterial
    {
        public static MaterialIndexViewModel DomainToIndexView (Material material) => new MaterialIndexViewModel ()
        {
            Id = material.Id,
            Descricao = material.Descricao,
            Preco = material.Preco,
            Unidade = material.Unidade
        };

        public static Material CreateViewToDomain (MaterialCreateViewModel materialCreate) => new Material ()
        {
            Descricao = materialCreate.Descricao,
            Preco = materialCreate.Preco,
            Unidade = materialCreate.Unidade
        };
        public static MaterialEditViewModel DomainToEditView (Material material) => new MaterialEditViewModel ()
        {
            Id = material.Id,
            Descricao = material.Descricao,
            Preco = material.Preco,
            Unidade = material.Unidade
        };
        public static Material EditViewToDomain (MaterialEditViewModel materialEdit) => new Material ()
        {
            Id = materialEdit.Id,
            Descricao = materialEdit.Descricao,
            Preco = materialEdit.Preco,
            Unidade = materialEdit.Unidade
        };
        public static MaterialDetailsViewModel DomainToDetailsView (Material material) => new MaterialDetailsViewModel ()
        {
            Id = material.Id,
            Descricao = material.Descricao,
            Preco = material.Preco,
            Unidade = material.Unidade
        };
    }
}
