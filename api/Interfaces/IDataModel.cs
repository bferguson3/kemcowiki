namespace api.Interfaces
{
    public interface IDataModel
    {
        // putting Id here and then making all the db models implement this interface
        //  allows us to guarantee that when we pull from the DB that the model will have 
        //  an Id property
         string Id { get; set; }
    }
}