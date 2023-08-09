// 리본컨트롤 BarItem
RibbonControl.BeginInvoke(new MethodInvoker(() => { //your code }));

modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>()
modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>()


uilder.Entity<T>().HasOptional(a => a.<...>).WithOptionalDependent().WillCascadeOnDelete(false);
base.OnModelCreating(builder);


builder.Entity<T>()
.HasRequired(d => d.<...>)
.WithMany(u => u.<....>)
.HasForeignKey(f=>f.<number>)
.WillCascadeOnDelete(false);

builder.Entity<T>().HasMany(p => p.<...>).WithOne(p => p..Person);

_ex.Rng.Interior.Color = ColorTranslator.ToOle(Color.LightCyan);
_ex.Rng.Borders.LineStyle = XlLineStyle.xlContinuous;
