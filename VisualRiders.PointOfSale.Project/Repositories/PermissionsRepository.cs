using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class PermissionsRepository
{
    private readonly List<Permission> _permissions = Data.Permissions;

    public Permission Create(CreateUpdatePermissionDto dto)
    {
        var permission = new Permission
        {
            Id = Guid.NewGuid(),
            Title = dto.Title
        };
        
        _permissions.Add(permission);

        return permission;
    }

    public List<Permission> GetAll()
    {
        return _permissions;
    }

    public Permission? GetById(Guid id)
    {
        return _permissions.Find(p => p.Id == id);
    }

    public void Update(Permission permission, CreateUpdatePermissionDto dto)
    {
        permission.Title = dto.Title;
    }

    public void Remove(Permission permission)
    {
        _permissions.Remove(permission);
    }
}