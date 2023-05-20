using System.Data.SqlClient;

namespace BLL
{
    public class news
    {
        public class InsertAnnexBLL
        {

            public int InsertAnnex(AnnexEntity annex)
            {
                return AnnexEntity.InsertAnnex(annex.Name);
            }
        }
    }
}