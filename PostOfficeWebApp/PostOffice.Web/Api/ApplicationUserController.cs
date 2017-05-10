<?xml version="1.0"?>
<doc>
    <assembly>
        <name>Microsoft.AspNet.Identity.EntityFramework</name>
    </assembly>
    <members>
        <member name="T:Microsoft.AspNet.Identity.EntityFramework.RoleStore`1">
            <summary>
                EntityFramework based implementation
            </summary>
            <typeparam name="TRole"></typeparam>
        </member>
        <member name="T:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3">
            <summary>
                EntityFramework based implementation
            </summary>
            <typeparam name="TRole"></typeparam>
            <typeparam name="TKey"></typeparam>
            <typeparam name="TUserRole"></typeparam>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.#ctor(System.Data.Entity.DbContext)">
            <summary>
                Constructor which takes a db context and wires up the stores with default instances using the context
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.FindByIdAsync(`1)">
            <summary>
                Find a role by id
            </summary>
            <param name="roleId"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.FindByNameAsync(System.String)">
            <summary>
                Find a role by name
            </summary>
            <param name="roleName"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.CreateAsync(`0)">
            <summary>
                Insert an entity
            </summary>
            <param name="role"></param>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.DeleteAsync(`0)">
            <summary>
                Mark an entity for deletion
            </summary>
            <param name="role"></param>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.UpdateAsync(`0)">
            <summary>
                Update an entity
            </summary>
            <param name="role"></param>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.Dispose">
            <summary>
                Dispose the store
            </summary>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.Dispose(System.Boolean)">
            <summary>
                If disposing, calls dispose on the Context.  Always nulls out the Context
            </summary>
            <param name="disposing"></param>
        </member>
        <member name="P:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.Context">
            <summary>
                Context for the store
            </summary>
        </member>
        <member name="P:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.DisposeContext">
            <summary>
                If true will call dispose on the DbContext during Dipose
            </summary>
        </member>
        <member name="P:Microsoft.AspNet.Identity.EntityFramework.RoleStore`3.Roles">
            <summary>
                Returns an IQueryable of users
            </summary>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`1.#ctor">
            <summary>
                Constructor
            </summary>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.RoleStore`1.#ctor(System.Data.Entity.DbContext)">
            <summary>
                Constructor
            </summary>
            <param name="context"></param>
        </member>
        <member name="T:Microsoft.AspNet.Identity.EntityFramework.UserStore`1">
            <summary>
                EntityFramework based user store implementation that supports IUserStore, IUserLoginStore, IUserClaimStore and
                IUserRoleStore
            </summary>
            <typeparam name="TUser"></typeparam>
        </member>
        <member name="T:Microsoft.AspNet.Identity.EntityFramework.UserStore`6">
            <summary>
                EntityFramework based user store implementation that supports IUserStore, IUserLoginStore, IUserClaimStore and
                IUserRoleStore
            </summary>
            <typeparam name="TUser"></typeparam>
            <typeparam name="TRole"></typeparam>
            <typeparam name="TKey"></typeparam>
            <typeparam name="TUserLogin"></typeparam>
            <typeparam name="TUserRole"></typeparam>
            <typeparam name="TUserClaim"></typeparam>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.#ctor(System.Data.Entity.DbContext)">
            <summary>
                Constructor which takes a db context and wires up the stores with default instances using the context
            </summary>
            <param name="context"></param>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.GetClaimsAsync(`0)">
            <summary>
                Return the claims for a user
            </summary>
            <param name="user"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.AddClaimAsync(`0,System.Security.Claims.Claim)">
            <summary>
                Add a claim to a user
            </summary>
            <param name="user"></param>
            <param name="claim"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.RemoveClaimAsync(`0,System.Security.Claims.Claim)">
            <summary>
                Remove a claim from a user
            </summary>
            <param name="user"></param>
            <param name="claim"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.GetEmailConfirmedAsync(`0)">
            <summary>
                Returns whether the user email is confirmed
            </summary>
            <param name="user"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.SetEmailConfirmedAsync(`0,System.Boolean)">
            <summary>
                Set IsConfirmed on the user
            </summary>
            <param name="user"></param>
            <param name="confirmed"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.SetEmailAsync(`0,System.String)">
            <summary>
                Set the user email
            </summary>
            <param name="user"></param>
            <param name="email"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.GetEmailAsync(`0)">
            <summary>
                Get the user's email
            </summary>
            <param name="user"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.FindByEmailAsync(System.String)">
            <summary>
                Find a user by email
            </summary>
            <param name="email"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.GetLockoutEndDateAsync(`0)">
            <summary>
                Returns the DateTimeOffset that represents the end of a user's lockout, any time in the past should be considered
                not locked out.
            </summary>
            <param name="user"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.SetLockoutEndDateAsync(`0,System.DateTimeOffset)">
            <summary>
                Locks a user out until the specified end date (set to a past date, to unlock a user)
            </summary>
            <param name="user"></param>
            <param name="lockoutEnd"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.IncrementAccessFailedCountAsync(`0)">
            <summary>
                Used to record when an attempt to access the user has failed
            </summary>
            <param name="user"></param>
            <returns></returns>
        </member>
        <member name="M:Microsoft.AspNet.Identity.EntityFramework.UserStore`6.ResetAccessFailedCountAsync(`0)">
            <summary>
                Used to reset the account access count, typically after the account is successfully accessed
            </summary>
            <param name="user"></param>
            <returns></returns>
        </member>
        <member name="