using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleInsuranceClaimMSAPIConnect.Models
{
    public partial class VehicleClaimDb_81316Context : DbContext
    {
        public VehicleClaimDb_81316Context()
        {
        }

        public VehicleClaimDb_81316Context(DbContextOptions<VehicleClaimDb_81316Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<InsuranceCompanies> InsuranceCompanies { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.Property(e => e.ClaimId)
                    .HasColumnName("Claim_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimStatus)
                    .HasColumnName("Claim_Status")
                    .HasMaxLength(50);

                entity.Property(e => e.DriverLicenceNo)
                    .HasColumnName("Driver_Licence_No")
                    .HasMaxLength(50);

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.VehicleBill)
                    .HasColumnName("Vehicle_Bill")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleCondition)
                    .HasColumnName("Vehicle_Condition")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("Fk_policyid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_user");
            });

            modelBuilder.Entity<InsuranceCompanies>(entity =>
            {
                entity.HasKey(e => e.CompanyIdentificationNo);

                entity.ToTable("Insurance_Companies");

                entity.Property(e => e.CompanyIdentificationNo)
                    .HasColumnName("Company_Identification_No")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyAddress)
                    .IsRequired()
                    .HasColumnName("Company_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyContact)
                    .IsRequired()
                    .HasColumnName("Company_Contact")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.Property(e => e.PolicyId)
                    .HasColumnName("Policy_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("Effective_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("Expiry_Date")
                    .HasColumnType("date");

                entity.Property(e => e.PolicyName)
                    .IsRequired()
                    .HasColumnName("Policy_Name")
                    .HasMaxLength(10);

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Policy)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_policy");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("Email_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasColumnName("Mobile_Number")
                    .HasMaxLength(10);

                entity.Property(e => e.NoOfClaims).HasColumnName("No_Of_Claims");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasColumnName("Pin_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasColumnName("Age")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleNo);

                entity.Property(e => e.VehicleNo)
                    .HasColumnName("Vehicle_No")
                    .ValueGeneratedNever();

                entity.Property(e => e.FuelType)
                    .HasColumnName("Fuel_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.GrossVehicleWeight)
                    .HasColumnName("Gross_Vehicle_Weight")
                    .HasMaxLength(50);

                entity.Property(e => e.OwnerId).HasColumnName("Owner_Id");

                entity.Property(e => e.VehicleCapacity)
                    .HasColumnName("Vehicle_Capacity")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleCompany)
                    .HasColumnName("Vehicle_Company")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleEngineNo)
                    .HasColumnName("Vehicle_Engine_No")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleLength)
                    .HasColumnName("Vehicle_Length")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleModelMaker)
                    .HasColumnName("Vehicle_Model/Maker")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleName)
                    .HasColumnName("Vehicle_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleOwner)
                    .HasColumnName("Vehicle_Owner")
                    .HasMaxLength(50);

                entity.Property(e => e.VehiclePower)
                    .HasColumnName("Vehicle_Power")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleType)
                    .HasColumnName("Vehicle_Type")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_vehicle");
            });
        }
    }
}
