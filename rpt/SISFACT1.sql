IF OBJECT_ID('CertFacturasDetalhe') IS NOT NULL     
	DROP PROCEDURE CertFacturasDetalhe 
go
CREATE PROCEDURE [dbo].[CertFacturasDetalhe] (
	@PacienteId int
)
AS
SET NOCOUNT ON

declare @selecao bit
declare @pre char(3)
set @selecao = 0

select @pre=cert_pre from Cert_sys_pre

Select @selecao as Seleccionar,
 CASE WHEN f.fecha >= CONVERT(datetime, '01-01-2011', 105) THEN CONVERT(varchar(3),
                          (SELECT     *
                            FROM          cert_sys_pre)) + ' ' + CONVERT(varchar(10), f.numero) ELSE CONVERT(varchar(10), f.numero) END AS Factura

,act.fecha as Data,act.numero as Peca ,tr.descripcion Tratamento, act.importe Valor, act.descuento Dto, act.Haber Recebido, 
act.rechazado Rejeitado,act.actuacion_id, isnull(ps.nombre,'')+' '+isnull(ps.apellido1,'')+' '+isnull(ps.apellido2,'') as Medico,ps.colegiado,ps.puntoservicio_id,act.factura_id as factura_id,act.generador_id as generador_id
from actuacion act, tratamiento tr , puntoservicio ps, factura f, Cert_sys_pre pre
where act.paciente_id=@PacienteId and act.tratamiento_id is not null and act.generador_id is not null
and act.tratamiento_id=tr.tratamiento_id and act.puntoservicio_id=ps.puntoservicio_id 
and f.factura_id=act.factura_id
and act.actuacion_id not in (select actuacion_id from Cert_Nc_DET where Cert_Nc_DET.actuacion_id=act.actuacion_id) and act.haber>0
go
IF OBJECT_ID('GetPacientes') IS NOT NULL     
	DROP PROCEDURE GetPacientes 
go
CREATE PROCEDURE [dbo].[GetPacientes] (
	@Data varchar(15)
)

AS


SET NOCOUNT ON

declare @selecao bit
set @selecao = 1

select distinct
@selecao as Seleccionar, 
dbo.paciente.nhc, isnull(dbo.paciente.nombre,'') + ' ' + isnull(dbo.paciente.apellido1,'') as Paciente,
Min(convert(datetime,dbo.contacto.fechaini,105)) as Data,
case when left(dbo.paciente.telefono,1) = '9' then isnull(dbo.paciente.telefono,'') else case when left(dbo.paciente.telefono2,1) = '9' then isnull(dbo.paciente.telefono2,'') else case when left(dbo.paciente.telefono3,1) = '9' then isnull(dbo.paciente.telefono3,'') else '' end end end  as 'Telemovel'
from dbo.paciente
inner join dbo.contacto on dbo.paciente.paciente_id=dbo.contacto.paciente_id
inner join dbo.puntoservicio on dbo.puntoservicio.puntoservicio_id=dbo.contacto.puntoservicio_id
where fechaini > convert(datetime,@data,105) and fechaini < convert(datetime,@Data,105) + 1
and anulado ='No'
group by dbo.paciente.nhc,isnull(dbo.paciente.nombre,'') + ' ' + isnull(dbo.paciente.apellido1,''),dbo.paciente.telefono,dbo.contacto.pacientenuevo,dbo.paciente.telefono2,dbo.paciente.telefono3
Order by dbo.paciente.nhc
go

declare @t as int

select @t=count(*) from cert_sys_ver

if @t = 0
	insert into cert_sys_ver values('1')
else
	update cert_sys_ver set cert_ver= convert(numeric(2),cert_ver) + 1
