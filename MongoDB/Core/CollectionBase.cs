using System;

namespace MongoDB.Core
{
    public abstract class CollectionBase
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CriadoPor { get; set; }

        protected CollectionBase()
        {
            Id = Guid.NewGuid().ToString();
            DataCriacao = DateTime.Now;
            CriadoPor = "Anonymous";
        }
    }
}
