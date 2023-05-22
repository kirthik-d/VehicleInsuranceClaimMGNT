﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleInsuranceClaimMSAPIConnect.Models;

namespace VehicleInsuranceClaimMSAPIConnect.Migrations
{
    [DbContext(typeof(VehicleClaimDb_81316Context))]
    partial class VehicleClaimDb_81316ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Claims", b =>
                {
                    b.Property<int>("ClaimId")
                        .HasColumnName("Claim_Id");

                    b.Property<string>("ClaimStatus")
                        .HasColumnName("Claim_Status")
                        .HasMaxLength(50);

                    b.Property<string>("DriverLicenceNo")
                        .HasColumnName("Driver_Licence_No")
                        .HasMaxLength(50);

                    b.Property<int>("PolicyId")
                        .HasColumnName("Policy_Id");

                    b.Property<int>("UserId")
                        .HasColumnName("User_Id");

                    b.Property<string>("VehicleBill")
                        .HasColumnName("Vehicle_Bill")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleCondition")
                        .HasColumnName("Vehicle_Condition")
                        .HasMaxLength(50);

                    b.HasKey("ClaimId");

                    b.HasIndex("PolicyId");

                    b.HasIndex("UserId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.InsuranceCompanies", b =>
                {
                    b.Property<int>("CompanyIdentificationNo")
                        .HasColumnName("Company_Identification_No");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnName("Company_Address")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyContact")
                        .IsRequired()
                        .HasColumnName("Company_Contact")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("Company_Name")
                        .HasMaxLength(50);

                    b.HasKey("CompanyIdentificationNo");

                    b.ToTable("Insurance_Companies");
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Login", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Policy", b =>
                {
                    b.Property<int>("PolicyId")
                        .HasColumnName("Policy_Id");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnName("Effective_Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnName("Expiry_Date")
                        .HasColumnType("date");

                    b.Property<string>("PolicyName")
                        .IsRequired()
                        .HasColumnName("Policy_Name")
                        .HasMaxLength(10);

                    b.Property<int>("VehicleId")
                        .HasColumnName("Vehicle_Id");

                    b.HasKey("PolicyId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("User_ID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnName("Age")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnName("Email_ID")
                        .HasMaxLength(50);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnName("Mobile_Number")
                        .HasMaxLength(10);

                    b.Property<int?>("NoOfClaims")
                        .HasColumnName("No_Of_Claims");

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnName("Pin_Code")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("User_Name")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Vehicles", b =>
                {
                    b.Property<int>("VehicleNo")
                        .HasColumnName("Vehicle_No");

                    b.Property<string>("FuelType")
                        .HasColumnName("Fuel_Type")
                        .HasMaxLength(50);

                    b.Property<string>("GrossVehicleWeight")
                        .HasColumnName("Gross_Vehicle_Weight")
                        .HasMaxLength(50);

                    b.Property<int?>("OwnerId")
                        .HasColumnName("Owner_Id");

                    b.Property<string>("VehicleCapacity")
                        .HasColumnName("Vehicle_Capacity")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleCompany")
                        .HasColumnName("Vehicle_Company")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleEngineNo")
                        .HasColumnName("Vehicle_Engine_No")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleLength")
                        .HasColumnName("Vehicle_Length")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleModelMaker")
                        .HasColumnName("Vehicle_Model/Maker")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleName")
                        .HasColumnName("Vehicle_Name")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleOwner")
                        .HasColumnName("Vehicle_Owner")
                        .HasMaxLength(50);

                    b.Property<string>("VehiclePower")
                        .HasColumnName("Vehicle_Power")
                        .HasMaxLength(50);

                    b.Property<string>("VehicleType")
                        .HasColumnName("Vehicle_Type")
                        .HasMaxLength(50);

                    b.HasKey("VehicleNo");

                    b.HasIndex("OwnerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Claims", b =>
                {
                    b.HasOne("VehicleInsuranceClaimMSAPIConnect.Models.Policy", "Policy")
                        .WithMany("Claims")
                        .HasForeignKey("PolicyId")
                        .HasConstraintName("Fk_policyid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VehicleInsuranceClaimMSAPIConnect.Models.Users", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Fk_user")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Policy", b =>
                {
                    b.HasOne("VehicleInsuranceClaimMSAPIConnect.Models.Vehicles", "Vehicle")
                        .WithMany("Policy")
                        .HasForeignKey("VehicleId")
                        .HasConstraintName("fk_policy");
                });

            modelBuilder.Entity("VehicleInsuranceClaimMSAPIConnect.Models.Vehicles", b =>
                {
                    b.HasOne("VehicleInsuranceClaimMSAPIConnect.Models.Users", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("fk_vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
