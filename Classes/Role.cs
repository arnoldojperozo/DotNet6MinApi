namespace DotNet6MinApi.Classes;

public record Role(int RoleID, string RoleName, int GroupID)
{
    public bool HasRole(int access, int roleID)
    {
        return roleID == (access & roleID);
    }
}