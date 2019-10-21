using Microsoft.EntityFrameworkCore;
using SGEP_Banco.Contexts;
using SGEP_Banco.Models;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Banco.RepositoryImplementations
{
    public class DefaultSaidaRepository : ISaidaRepository
    {
        private readonly DefaultContext _db;
        public DefaultSaidaRepository(DefaultContext db) => _db = db;
        public void Add(Saida saida)
        {
            _db.Add(ModelConverter.DomainToDB(saida));
            _db.SaveChanges();
        }

        public async Task AddAsync(Saida saida)
        {
            _db.Add(ModelConverter.DomainToDB(saida));
            await _db.SaveChangesAsync();
        }

        public Saida Get(ulong id)
        {
            SaidaDBModel saidaDB = _db.Saida.Find(id);
            FuncionarioDBModel funcionarioDB = _db.Funcionario.Find(saidaDB.FuncionarioID);
            MaterialDBModel materialDB = _db.Material.Find(saidaDB.MaterialID);
            ProjetoDBModel projetoDB = _db.Projeto.Find(saidaDB.ProjetoID);
            ProjetoFinalizadoDBModel projetoFinalizadoDB = _db.ProjetoFinalizado.Find(saidaDB.ProjetoID);

            return ModelConverter.DBToDomain(saidaDB, funcionarioDB, materialDB, projetoDB, projetoFinalizadoDB);
        }

        public IEnumerable<Saida> GetAll()
        {
            IList<Saida> saidas = new List<Saida>();
            IList<SaidaDBModel> saidaDBs = _db.Saida.ToList();

            foreach (SaidaDBModel s in saidaDBs) 
            {
                FuncionarioDBModel funcionarioDB = _db.Funcionario.Find(s.FuncionarioID);
                MaterialDBModel materialDB = _db.Material.Find(s.MaterialID);
                ProjetoDBModel projetoDB = _db.Projeto.Find(s.ProjetoID);
                ProjetoFinalizadoDBModel projetoFinalizadoDB = _db.ProjetoFinalizado.Find(s.ProjetoID);

                saidas.Add(ModelConverter.DBToDomain(s, funcionarioDB, materialDB, projetoDB, projetoFinalizadoDB));
            }
            return saidas;
        }

        public async Task<IEnumerable<Saida>> GetAllAsync()
        {
            IList<Saida> saidas = new List<Saida>();
            IList<SaidaDBModel> saidaDBs = await _db.Saida.ToListAsync();

            foreach (SaidaDBModel s in saidaDBs)
            {
                FuncionarioDBModel funcionarioDB = await _db.Funcionario.FindAsync(s.FuncionarioID);
                MaterialDBModel materialDB = await _db.Material.FindAsync(s.MaterialID);
                ProjetoDBModel projetoDB = await _db.Projeto.FindAsync(s.ProjetoID);
                ProjetoFinalizadoDBModel projetoFinalizadoDB = await _db.ProjetoFinalizado.FindAsync(s.ProjetoID);

                saidas.Add(ModelConverter.DBToDomain(s, funcionarioDB, materialDB, projetoDB, projetoFinalizadoDB));
            }
            return saidas;
        }

        public void Update(Saida saida)
        {
            _db.Update(ModelConverter.DomainToDB(saida));
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Saida saida)
        {
            _db.Update(ModelConverter.DomainToDB(saida));
            await _db.SaveChangesAsync();
        }
    }
}
