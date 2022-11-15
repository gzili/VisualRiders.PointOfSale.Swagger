using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class RolesRepository
{
    private readonly PermissionsRepository _permissionsRepository;
    private readonly List<Role> _roles = Data.Roles;

    public RolesRepository(PermissionsRepository permissionsRepository)
    {
        _permissionsRepository = permissionsRepository;
    }

    public Role Create(CreateUpdateRoleDto dto)
    {
        var role = new Role
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Permissions = new List<Permission>()
        };

        foreach (var permissionId in dto.PermissionIds)
        {
            var permission = _permissionsRepository.GetById(permissionId);

            if (permission == null)
            {
                throw new Exception();
            }
            
            role.Permissions.Add(permission);
        }
        
        _roles.Add(role);

        return role;
    }

    public List<Role> GetAll()
    {
        return _roles;
    }

    public Role? GetById(Guid id)
    {
        return _roles.Find(r => r.Id == id);
    }

    public void Update(Role role, CreateUpdateRoleDto dto)
    {
        role.Title = dto.Title;

        var permissions = new List<Permission>();
        
        foreach (var permissionId in dto.PermissionIds)
        {
            var permission = _permissionsRepository.GetById(permissionId);

            if (permission == null)
            {
                throw new Exception();
            }
            
            permissions.Add(permission);
        }

        role.Permissions = permissions;
    }

    public void Delete(Role role)
    {
        _roles.Remove(role);
    }
}