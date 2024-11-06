using Assignment.Core.Helpers;

namespace Assignment.Repository.Repositories;

public class KlantenParameters : QueryStringParameters
{
    public KlantenParameters()
    {
        OrderBy = "Naam";
    }
}
