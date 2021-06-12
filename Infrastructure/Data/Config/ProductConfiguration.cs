using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) /*bayad implenment beshe*/
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired(); /*age khasti HasMaxLength() bezari ye meghdari bede to seed data be moshkel nakhori. ya aslan ese alan nanevis*/
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)"); /*chon sql server va sqlite decimal support nemikone*/
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId); /*in khat bara relation bein jadavele*/
            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId); /*in khat bara relation bein jadavele*/
        }
    } /*ghablana in tanzimato dakhel OnModelCreating dakhel file Context gharar midadim. in ravesh jadide*/
}
