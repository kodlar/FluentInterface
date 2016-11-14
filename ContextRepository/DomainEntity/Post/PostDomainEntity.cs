using ContextRepository.DomainEntity.Common;
using ContextRepository.Enums;
using ContextRepository.InfraStructure.Init;

namespace ContextRepository.DomainEntity.Post
{
   // [DataContract(Namespace = "")]
    internal class PostDomainEntity : IPostDomainEntity , ICompositeViewModelInitializer
    {
        private  ICommonDomainEntity _composite;
        
        public TypeEnumPool Type => TypeEnumPool.Post;
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long? Id
        {
            get
            {
                return this._composite.Id;
            }
            set
            {
                this._composite.Id = value;
            }
        }

        public string Title { get; set; }

        public string SeoKeys { get; set; }

        public void Initialize(IDomainEntity compositeViewModel)
        {
            this._composite = compositeViewModel as ICommonDomainEntity;
        }
    }
}
