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
            FuncionarioDBModel funcionarioDB = _db.Funcionario.Find(saidaDB.Funcionario);
            MaterialDBModel materialDB = _db.Material.Find(saidaDB.Material);
            ProjetoDBModel projetoDB = _db.Projeto.Find(saidaDB.AlmoxarifadoDestino);
            ProjetoFinalizadoDBModel projetoFinalizadoDB = _db.ProjetoFinalizado.Find(saidaDB.AlmoxarifadoDestino);

            return ModelConverter.DBToDomain(saidaDB);
        }

        public IEnumerable<Saida> GetAll()
        {
            IList<Saida> saidas = new List<Saida>();
            IList<SaidaDBModel> saidaDBs = _db.Saida.ToList();

            foreach (SaidaDBModel s in saidaDBs) 
            {
                FuncionarioDBModel funcionarioDB = _db.Funcionario.Find(s.Funcionario);
                MaterialDBModel materialDB = _db.Material.Find(s.Material);
                ProjetoDBModel projetoDB = _db.Projeto.Find(s.AlmoxarifadoDestino);
                ProjetoFinalizadoDBModel projetoFinalizadoDB = _db.ProjetoFinalizado.Find(s.AlmoxarifadoDestino);

                saidas.Add(ModelConverter.DBToDomain(s));
            }
            return saidas;
        }

        public async Task<IEnumerable<Saida>> GetAllAsync()
        {
            IList<Saida> saidas = new List<Saida>();
            IList<SaidaDBModel> saidaDBs = await _db.Saida.ToListAsync();

            foreach (SaidaDBModel s in saidaDBs)
            {
                FuncionarioDBModel funcionarioDB = await _db.Funcionario.FindAsync(s.Funcionario);
                MaterialDBModel materialDB = await _db.Material.FindAsync(s.Material);
                ProjetoDBModel projetoDB = await _db.Projeto.FindAsync(s.AlmoxarifadoDestino);
                ProjetoFinalizadoDBModel projetoFinalizadoDB = await _db.ProjetoFinalizado.FindAsync(s.AlmoxarifadoDestino);

                saidas.Add(ModelConverter.DBToDomain(s));
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
