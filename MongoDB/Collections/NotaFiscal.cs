using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Core;
using System;

namespace MongoDB.Collections
{
    public class NotaFiscal : CollectionBase
    {
        public int Numero { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataEmissao { get; set; }

        public NotaFiscal()
        {
        }

        public NotaFiscal(int numero, string cnpj, DateTime dataEmissao)
        {
            Numero = numero;
            Cnpj = cnpj;
            DataEmissao = dataEmissao;
        }

    }
}
