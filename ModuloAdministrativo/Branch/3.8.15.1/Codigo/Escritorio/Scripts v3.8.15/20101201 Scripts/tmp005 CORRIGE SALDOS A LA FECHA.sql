
declare 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdVendedor as bigint,
@IdRuta as bigint,
@Fecha as datetime,
@BorrarSaldos as char(1)

set @IdCedis = 2
set @Fecha = '20101120'
set @IdVendedor = 3251
set @IdRuta = 737
set @BorrarSaldos = 'S'

if @BorrarSaldos = 'S'
begin

	delete from VendedoresSaldos where IdCedis = IdCedis and Fecha > @Fecha and IdSurtido > 0 -- and IdVendedor = @IdVendedor 

	declare  ActSaldos cursor for
		select Surtidos.IdCedis, Surtidos.IdSurtido, SurtidosVendedor.IdVendedor, Surtidos.Fecha
		from Surtidos 
		inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido 
		where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha > @Fecha -- and Surtidos.IdRuta = @IdRuta -- and Surtidos.Status = 'C' 
		order by SurtidosVendedor.IdVendedor, Surtidos.Fecha, Surtidos.IdSurtido
	open ActSaldos

	fetch next from ActSaldos into @IdCedis, @IdSurtido, @IdVendedor, @Fecha
	while (@@fetch_status = 0)
	begin

		--select @IdCedis, @IdSurtido, @IdVendedor, @Fecha

		exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1
		
		if exists(select IdVendedor from VendedoresCargosAbonos where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha )
		begin	
			update VendedoresSaldos set Otros = Importe, SaldoActual = SaldoAnterior + Saldo + Importe
			from VendedoresSaldos, VendedoresCargosAbonos 
			where VendedoresSaldos.IdCedis = VendedoresCargosAbonos.IdCedis and VendedoresSaldos.IdVendedor = VendedoresCargosAbonos.IdVendedor 
				and VendedoresSaldos.Fecha = @Fecha 
		end
		
		fetch next from ActSaldos into @IdCedis, @IdSurtido, @IdVendedor, @Fecha
	end
	close ActSaldos
	deallocate ActSaldos		
end

select *
from VendedoresSaldos 
where IdCedis = 2 --and IdVendedor = @IdVendedor 
order by IdVendedor, Fecha, IdSurtido 

--exec up_VendedoresSaldos @IdCedis, @IdSurtido, @IdVendedor, @Fecha, 1

--insert into Ventas values (2, 3098, 1, 8840, 'DEV02', '20101121', 9900, 0, 0, 9956, 0, NULL)
--insert into VentasDetalle values (2, 3098, 1, 8840, 201, 'DEV02', -24, 9.95, 0, 0, 0, 0)
