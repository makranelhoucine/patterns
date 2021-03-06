// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Pattern.Repository
{
    using System;
    using System.Collections.Generic;

    public partial class AnimalConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Animal>
    {
        public AnimalConfiguration()
            : this("dbo")
        {
        }

        public AnimalConfiguration(string schema)
        {
            ToTable("Animal", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Legs).HasColumnName(@"Legs").HasColumnType("int").IsRequired();
            Property(x => x.Food).HasColumnName(@"Food").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.FamilyId).HasColumnName(@"FamilyId").HasColumnType("int").IsRequired();

            HasRequired(a => a.Family).WithMany(b => b.Animals).HasForeignKey(c => c.FamilyId).WillCascadeOnDelete(false);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
