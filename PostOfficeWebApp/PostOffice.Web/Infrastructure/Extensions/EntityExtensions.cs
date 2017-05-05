using PostOffice.Model.Models;
using PostOffice.Web.Models;
using System;

namespace PostOffice.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }

        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {
            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.POID = appUserViewModel.POID;
        }

        public static void UpdateDistrict(this District dis, DistrictViewModel vm) {
            dis.Code = vm.Code;
            dis.CreatedBy = vm.CreatedBy;
            dis.CreatedDate = vm.CreatedDate;
            dis.ID = vm.ID;
            dis.MetaDescription = vm.MetaDescription;
            dis.MetaKeyWord = vm.MetaKeyWord;
            dis.Name = vm.Name;
            dis.Status = vm.Status;
            dis.UpdatedBy = vm.UpdatedBy;
            dis.UpdatedDate = vm.UpdatedDate;
        }

        public static void UpdatePO(this PO po, POViewModel vm)
        {
            po.Code = vm.Code;
            po.CreatedBy = vm.CreatedBy;
            po.CreatedDate = vm.CreatedDate;
            po.DistrictID = vm.DistrictID;
            po.ID = vm.ID;
            po.MetaDescription = vm.MetaDescription;
            po.MetaKeyWord = vm.MetaKeyWord;
            po.Name = vm.Name;
            po.POAddress = vm.POAddress;
            po.POMobile = vm.POMobile;
            po.POStyle = vm.POStyle;
            po.UpdatedBy = vm.UpdatedBy;
            po.UpdatedDate = vm.UpdatedDate;
          
        }
    }
}