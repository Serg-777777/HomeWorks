
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace WebApp_DEBUG.Domain.Model.UserModel;

public class User: AEntity, IEquatable<User>, IComparable<User>
{
	public const string EntityName = "User";
	public User() : base(EntityName) { }

	public int Id { get; set; }
	public string Login { get; set; } = String.Empty;
	public string Password { get; set; } = String.Empty;
	public string Email { get; set; } = String.Empty;
	public bool isDeleted{ get; set; } = false;
	public required UserRole UserRole { set; get; }

	public int CompareTo(User? other)
	{
		return this.Id.CompareTo(other?.Id);
	}

	public bool Equals(User? other)
	{
		if (other != null && (other is User u))
			return this.Id == u.Id;
		return false;
	}

}

public class UserInfo:User
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public int? Age { get; set; }
	public string? Country { get; set; }
	public string? City { get; set; }
}

public class UserSetting : User
{
	public bool DownloadFiles { get; set; } = false;
	public bool LoadFiles { get; set; } = true;
}

//[ComplexType] добaвлен через конфигурацию
public class UserRole
{
	public required string RoleName { set; get; }
}
