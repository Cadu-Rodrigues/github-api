public class RepositoryMapper
{
    public List<Repository> convert(RepositoriesApiResponse response)
    {
        List<Repository> array = new List<Repository>();
        foreach (Item i in response.Items)
        {
            Repository toAdd = new Repository();
            toAdd.Name = i.name;
            toAdd.OwnerName = i.owner.login;
            toAdd.Description = i.description;
            toAdd.URL = i.html_url;
            toAdd.CreationDate = i.created_at;
            toAdd.UpdatedDate = i.updated_at;
            toAdd.Stars = i.stargazers_count;
            toAdd.Watchers = i.watchers;
            toAdd.Language = i.language;
            array.Add(toAdd);
        }
        return array;
    }
}