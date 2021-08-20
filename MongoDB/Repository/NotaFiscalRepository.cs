using MongoDB.Collections;
using MongoDB.Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public class NotaFiscalRepository : MongoConnectionBase<NotaFiscal>
    {
        public void Salvar(IEnumerable<NotaFiscal> notasFiscais)
        {
            Collection.InsertMany(notasFiscais);
        }

        public long Quantidade()
        {
            return Collection.EstimatedDocumentCount();
        }

        public async Task<IEnumerable<NotaFiscal>> ListarTodas()
        {
            return await Collection.AsQueryable().ToListAsync();
        }

        public NotaFiscal ObterPorId(Guid id)
        {
            //return Collection.AsQueryable().Where(x => x.Id == id.ToString()).FirstOrDefault();
            return Collection.Find(x => x.Id == id.ToString()).FirstOrDefault();
        }

        public bool Deletar(Guid id)
        {
            var delete = Collection.DeleteOne(x => x.Id == id.ToString());
            return delete.DeletedCount > 0;
        }
    }
}
