public class RepositoryMapper
{
    public List<Repository> convert(RepositoriesApiResponse response)
    {
        List<Repository> array = new List<Repository>();
        foreach (Item i in response.Items)
        {
            Repository toAdd = new Repository();
            toAdd.Name = i.Name;
            toAdd.OwnerName = i.Owner.Login;
            toAdd.Description = i.Description;
            toAdd.URL = i.HtmlUrl;
            toAdd.CreationDate = i.CreatedAt;
            toAdd.UpdatedDate = i.UpdatedAt;
            toAdd.Stars = i.StargazersCount;
            toAdd.Watchers = i.Watchers;
            toAdd.Language = i.Language;
            array.Add(toAdd);
        }
        return array;
    }
}