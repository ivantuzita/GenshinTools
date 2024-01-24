using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models {
    [Keyless]
    public class UserWeapon {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int WeaponId { get; set; }
    }
}
