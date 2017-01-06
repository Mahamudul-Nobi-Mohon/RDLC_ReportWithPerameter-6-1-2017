create procedure GetOrdersReport
(
 @FromDate datetime,
 @ToDate datetime
)
as
select OrderId,ShippedDate,ShipName,ShipAddress,ShipCity,ShipCountry from orders
where OrderDate between @FromDate and @ToDate
order by OrderDate asc
