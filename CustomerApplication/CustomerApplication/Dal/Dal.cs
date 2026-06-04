namespace CustomerApplication.Dal
{
    
       public interface IDal
        {
            void Add();
            void Update();
        }

        public class EfDal : IDal
        {
            public void Add()
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }
        }
        public class AdoDal : IDal
        {
            public void Add()
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }
        }
    
}
