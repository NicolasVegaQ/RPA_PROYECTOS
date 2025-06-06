// Crear tabla
tabla_for_prec_inv = new System.Data.DataTable();
tabla_for_prec_inv.Columns.Add("Código", typeof(int));
tabla_for_prec_inv.Columns.Add("Código de la unidad", typeof(int));
tabla_for_prec_inv.Columns.Add("Nombre", typeof(string));
tabla_for_prec_inv.Columns.Add("Nombre largo", typeof(string));
tabla_for_prec_inv.Columns.Add("Déscripción del artículo", typeof(string));
tabla_for_prec_inv.Columns.Add("Referencia", typeof(string));
tabla_for_prec_inv.Columns.Add("Código de barras", typeof(string));
tabla_for_prec_inv.Columns.Add("Código del grupo", typeof(int));
tabla_for_prec_inv.Columns.Add("Característica 1", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 2", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 3", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 4", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 5", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 6", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 7", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 8", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 9", typeof(string));
tabla_for_prec_inv.Columns.Add("Característica 10", typeof(string));
tabla_for_prec_inv.Columns.Add("Código de la familia", typeof(int));
tabla_for_prec_inv.Columns.Add("Cód. característica de la familia", typeof(int));
tabla_for_prec_inv.Columns.Add("Facturable", typeof(string));
tabla_for_prec_inv.Columns.Add("Base precio", typeof(string));
tabla_for_prec_inv.Columns.Add("Tipo", typeof(string));
tabla_for_prec_inv.Columns.Add("Pesable", typeof(string));
tabla_for_prec_inv.Columns.Add("Precio base", typeof(double));
tabla_for_prec_inv.Columns.Add("Existencias", typeof(double));
tabla_for_prec_inv.Columns.Add("Costo unitario", typeof(double));
tabla_for_prec_inv.Columns.Add("Tarifa de IVA Ventas", typeof(double));
tabla_for_prec_inv.Columns.Add("Clase de imp. consumo Ventas", typeof(double));
tabla_for_prec_inv.Columns.Add("Tarifa de imp. consumo Ventas", typeof(double));
tabla_for_prec_inv.Columns.Add("Cód. impuesto de IVA Ventas", typeof(string));
tabla_for_prec_inv.Columns.Add("Cód. impuesto de consumo Ventas", typeof(string));
tabla_for_prec_inv.Columns.Add("Método valuación inf tributaria", typeof(int));
tabla_for_prec_inv.Columns.Add("Método valuación inf contable", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa de IVA Compras", typeof(double));
tabla_for_prec_inv.Columns.Add("Clase de imp. consumo Compras", typeof(string));
tabla_for_prec_inv.Columns.Add("Tarifa de imp. consumo Compras", typeof(double));
tabla_for_prec_inv.Columns.Add("Cód. impuesto de IVA Compras", typeof(int));
tabla_for_prec_inv.Columns.Add("Cód. impuesto de consumo Compras", typeof(int));
tabla_for_prec_inv.Columns.Add("Medida Imp. bebidas", typeof(string));
tabla_for_prec_inv.Columns.Add("Gramos Imp. bebidas", typeof(string));
tabla_for_prec_inv.Columns.Add("Tarifa Imp. bebidas", typeof(string));
tabla_for_prec_inv.Columns.Add("Tarifa Imp. comestibles", typeof(string));
tabla_for_prec_inv.Columns.Add("Código Imp. gasolina venta", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa gasolina venta", typeof(double));
tabla_for_prec_inv.Columns.Add("Código Imp. gasolina compra", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa gasolina compra", typeof(double));
tabla_for_prec_inv.Columns.Add("Código Imp. bolsa venta", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa bolsa venta", typeof(double));
tabla_for_prec_inv.Columns.Add("Código Imp. bolsa compra", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa bolsa compra", typeof(double));
tabla_for_prec_inv.Columns.Add("Código Imp. carbono venta", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa carbono venta", typeof(double));
tabla_for_prec_inv.Columns.Add("Código Imp. carbono compra", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa carbono compra", typeof(double));
tabla_for_prec_inv.Columns.Add("Código Imp. cannabis venta", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa cannabis venta", typeof(double));
tabla_for_prec_inv.Columns.Add("Código Imp. cannabis compra", typeof(int));
tabla_for_prec_inv.Columns.Add("Tarifa cannabis compra", typeof(double));


// Contar las filas en precios_inventario
int rowCount = precios_inventario.Rows.Count;

// Iterar sobre las filas de precios_inventario
for (int i = 0; i < rowCount; i++)
{
    // Crear una nueva fila en tabla_for_prec_inv
    System.Data.DataRow newRow = tabla_for_prec_inv.NewRow();

    // Declarar variables auxiliares para TryParse
    int codigo = 0, codigoUnidad = 0, codigoGrupo = 0, codigoFamilia = 0, codCaracteristicaFamilia = 0;
    int metodoValuacionTributaria = 0, metodoValuacionContable = 0, codigoImpGasolinaVenta = 0;
    int codigoImpGasolinaCompra = 0, codigoImpBolsaVenta = 0, codigoImpBolsaCompra = 0;
    int codigoImpCarbonoVenta = 0, codigoImpCarbonoCompra = 0, codigoImpCannabisVenta = 0, codigoImpCannabisCompra = 0;

    double precioBase = 0.0, existencias = 0.0, costoUnitario = 0.0, tarifaIVAVentas = 0.0;
    double claseImpConsumoVentas = 0.0, tarifaImpConsumoVentas = 0.0, tarifaIVACompras = 0.0;
    double tarifaImpConsumoCompras = 0.0, tarifaGasolinaVenta = 0.0, tarifaGasolinaCompra = 0.0;
    double tarifaBolsaVenta = 0.0, tarifaBolsaCompra = 0.0, tarifaCarbonoVenta = 0.0;
    double tarifaCarbonoCompra = 0.0, tarifaCannabisVenta = 0.0, tarifaCannabisCompra = 0.0;

    // Validar y asignar valores para columnas de tipo int
    newRow["Código"] = precios_inventario.Rows[i]["Código"] != null && int.TryParse(precios_inventario.Rows[i]["Código"].ToString(), out codigo) ? codigo : 0;
    newRow["Código de la unidad"] = precios_inventario.Rows[i]["Código de la unidad"] != null && int.TryParse(precios_inventario.Rows[i]["Código de la unidad"].ToString(), out codigoUnidad) ? codigoUnidad : 0;
    newRow["Código del grupo"] = precios_inventario.Rows[i]["Código del grupo"] != null && int.TryParse(precios_inventario.Rows[i]["Código del grupo"].ToString(), out codigoGrupo) ? codigoGrupo : 0;
    newRow["Código de la familia"] = precios_inventario.Rows[i]["Código de la familia"] != null && int.TryParse(precios_inventario.Rows[i]["Código de la familia"].ToString(), out codigoFamilia) ? codigoFamilia : 0;
    newRow["Cód. característica de la familia"] = precios_inventario.Rows[i]["Cód. característica de la familia"] != null && int.TryParse(precios_inventario.Rows[i]["Cód. característica de la familia"].ToString(), out codCaracteristicaFamilia) ? codCaracteristicaFamilia : 0;
    newRow["Método valuación inf tributaria"] = precios_inventario.Rows[i]["Método valuación inf tributaria"] != null && int.TryParse(precios_inventario.Rows[i]["Método valuación inf tributaria"].ToString(), out metodoValuacionTributaria) ? metodoValuacionTributaria : 0;
    newRow["Método valuación inf contable"] = precios_inventario.Rows[i]["Método valuación inf contable"] != null && int.TryParse(precios_inventario.Rows[i]["Método valuación inf contable"].ToString(), out metodoValuacionContable) ? metodoValuacionContable : 0;
 newRow["Código Imp. gasolina venta"] = precios_inventario.Rows[i]["Código Imp. gasolina venta"] != null &&
                                        int.TryParse(precios_inventario.Rows[i]["Código Imp. gasolina venta"].ToString(), out codigoImpGasolinaVenta) ? 
                                        codigoImpGasolinaVenta : 0;
 
 newRow["Código Imp. gasolina compra"] = precios_inventario.Rows[i]["Código Imp. gasolina compra"] != null &&
                                         int.TryParse(precios_inventario.Rows[i]["Código Imp. gasolina compra"].ToString(), out codigoImpGasolinaCompra) ? 
                                         codigoImpGasolinaCompra : 0;
 
 newRow["Código Imp. bolsa venta"] = precios_inventario.Rows[i]["Código Imp. bolsa venta"] != null &&
                                     int.TryParse(precios_inventario.Rows[i]["Código Imp. bolsa venta"].ToString(), out codigoImpBolsaVenta) ? 
                                     codigoImpBolsaVenta : 0;
 
 newRow["Código Imp. bolsa compra"] = precios_inventario.Rows[i]["Código Imp. bolsa compra"] != null &&
                                      int.TryParse(precios_inventario.Rows[i]["Código Imp. bolsa compra"].ToString(), out codigoImpBolsaCompra) ? 
                                      codigoImpBolsaCompra : 0;
 
 newRow["Código Imp. carbono venta"] = precios_inventario.Rows[i]["Código Imp. carbono venta"] != null &&
                                       int.TryParse(precios_inventario.Rows[i]["Código Imp. carbono venta"].ToString(), out codigoImpCarbonoVenta) ? 
                                       codigoImpCarbonoVenta : 0;
 
 newRow["Código Imp. carbono compra"] = precios_inventario.Rows[i]["Código Imp. carbono compra"] != null &&
                                        int.TryParse(precios_inventario.Rows[i]["Código Imp. carbono compra"].ToString(), out codigoImpCarbonoCompra) ? 
                                        codigoImpCarbonoCompra : 0;
 
 newRow["Código Imp. cannabis venta"] = precios_inventario.Rows[i]["Código Imp. cannabis venta"] != null &&
                                        int.TryParse(precios_inventario.Rows[i]["Código Imp. cannabis venta"].ToString(), out codigoImpCannabisVenta) ? 
                                        codigoImpCannabisVenta : 0;
 
 newRow["Código Imp. cannabis compra"] = precios_inventario.Rows[i]["Código Imp. cannabis compra"] != null &&
                                         int.TryParse(precios_inventario.Rows[i]["Código Imp. cannabis compra"].ToString(), out codigoImpCannabisCompra) ? 
                                         codigoImpCannabisCompra : 0;


    // Validar y asignar valores para columnas de tipo double
    newRow["Precio base"] = precios_inventario.Rows[i]["Precio base"] != null && double.TryParse(precios_inventario.Rows[i]["Precio base"].ToString(), out precioBase) ? precioBase : 0.0;
    newRow["Existencias"] = precios_inventario.Rows[i]["Existencias"] != null && double.TryParse(precios_inventario.Rows[i]["Existencias"].ToString(), out existencias) ? existencias : 0.0;
    newRow["Costo unitario"] = precios_inventario.Rows[i]["Costo unitario"] != null && double.TryParse(precios_inventario.Rows[i]["Costo unitario"].ToString(), out costoUnitario) ? costoUnitario : 0.0;
    newRow["Tarifa de IVA Ventas"] = precios_inventario.Rows[i]["Tarifa de IVA Ventas"] != null && double.TryParse(precios_inventario.Rows[i]["Tarifa de IVA Ventas"].ToString(), out tarifaIVAVentas) ? tarifaIVAVentas : 0.0;
 newRow["Clase de imp. consumo Ventas"] = precios_inventario.Rows[i]["Clase de imp. consumo Ventas"] != null &&
                                          double.TryParse(precios_inventario.Rows[i]["Clase de imp. consumo Ventas"].ToString(), out claseImpConsumoVentas) ? 
                                          claseImpConsumoVentas : 0.0;
 
 newRow["Tarifa de imp. consumo Ventas"] = precios_inventario.Rows[i]["Tarifa de imp. consumo Ventas"] != null &&
                                           double.TryParse(precios_inventario.Rows[i]["Tarifa de imp. consumo Ventas"].ToString(), out tarifaImpConsumoVentas) ? 
                                           tarifaImpConsumoVentas : 0.0;
 
 newRow["Tarifa de IVA Compras"] = precios_inventario.Rows[i]["Tarifa de IVA Compras"] != null &&
                                    double.TryParse(precios_inventario.Rows[i]["Tarifa de IVA Compras"].ToString(), out tarifaIVACompras) ? 
                                    tarifaIVACompras : 0.0;
 
 newRow["Tarifa de imp. consumo Compras"] = precios_inventario.Rows[i]["Tarifa de imp. consumo Compras"] != null &&
                                            double.TryParse(precios_inventario.Rows[i]["Tarifa de imp. consumo Compras"].ToString(), out tarifaImpConsumoCompras) ? 
                                            tarifaImpConsumoCompras : 0.0;
 
 newRow["Tarifa gasolina venta"] = precios_inventario.Rows[i]["Tarifa gasolina venta"] != null &&
                                   double.TryParse(precios_inventario.Rows[i]["Tarifa gasolina venta"].ToString(), out tarifaGasolinaVenta) ? 
                                   tarifaGasolinaVenta : 0.0;
 
 newRow["Tarifa gasolina compra"] = precios_inventario.Rows[i]["Tarifa gasolina compra"] != null &&
                                    double.TryParse(precios_inventario.Rows[i]["Tarifa gasolina compra"].ToString(), out tarifaGasolinaCompra) ? 
                                    tarifaGasolinaCompra : 0.0;
 
 newRow["Tarifa bolsa venta"] = precios_inventario.Rows[i]["Tarifa bolsa venta"] != null &&
                                double.TryParse(precios_inventario.Rows[i]["Tarifa bolsa venta"].ToString(), out tarifaBolsaVenta) ? 
                                tarifaBolsaVenta : 0.0;
 
 newRow["Tarifa bolsa compra"] = precios_inventario.Rows[i]["Tarifa bolsa compra"] != null &&
                                 double.TryParse(precios_inventario.Rows[i]["Tarifa bolsa compra"].ToString(), out tarifaBolsaCompra) ? 
                                 tarifaBolsaCompra : 0.0;
 
 newRow["Tarifa carbono venta"] = precios_inventario.Rows[i]["Tarifa carbono venta"] != null &&
                                  double.TryParse(precios_inventario.Rows[i]["Tarifa carbono venta"].ToString(), out tarifaCarbonoVenta) ? 
                                  tarifaCarbonoVenta : 0.0;
 
 newRow["Tarifa carbono compra"] = precios_inventario.Rows[i]["Tarifa carbono compra"] != null &&
                                   double.TryParse(precios_inventario.Rows[i]["Tarifa carbono compra"].ToString(), out tarifaCarbonoCompra) ? 
                                   tarifaCarbonoCompra : 0.0;
 
 newRow["Tarifa cannabis venta"] = precios_inventario.Rows[i]["Tarifa cannabis venta"] != null &&
                                   double.TryParse(precios_inventario.Rows[i]["Tarifa cannabis venta"].ToString(), out tarifaCannabisVenta) ? 
                                   tarifaCannabisVenta : 0.0;
 
 newRow["Tarifa cannabis compra"] = precios_inventario.Rows[i]["Tarifa cannabis compra"] != null &&
                                    double.TryParse(precios_inventario.Rows[i]["Tarifa cannabis compra"].ToString(), out tarifaCannabisCompra) ? 
                                    tarifaCannabisCompra : 0.0;

    // Validar y asignar valores para columnas de tipo string
    newRow["Nombre"] = precios_inventario.Rows[i]["Nombre"] != null ? precios_inventario.Rows[i]["Nombre"].ToString() : string.Empty;
    newRow["Nombre largo"] = precios_inventario.Rows[i]["Nombre largo"] != null ? precios_inventario.Rows[i]["Nombre largo"].ToString() : string.Empty;
    newRow["Déscripción del artículo"] = precios_inventario.Rows[i]["Déscripción del artículo"] != null ? precios_inventario.Rows[i]["Déscripción del artículo"].ToString() : string.Empty;
    newRow["Referencia"] = precios_inventario.Rows[i]["Referencia"] != null ? precios_inventario.Rows[i]["Referencia"].ToString() : string.Empty;
    newRow["Código de barras"] = precios_inventario.Rows[i]["Código de barras"] != null ? precios_inventario.Rows[i]["Código de barras"].ToString() : string.Empty;
 newRow["Característica 1"] = precios_inventario.Rows[i]["Característica 1"] != null ?
                               precios_inventario.Rows[i]["Característica 1"].ToString() : string.Empty;
 
 newRow["Característica 2"] = precios_inventario.Rows[i]["Característica 2"] != null ?
                               precios_inventario.Rows[i]["Característica 2"].ToString() : string.Empty;
 
 newRow["Característica 3"] = precios_inventario.Rows[i]["Característica 3"] != null ?
                               precios_inventario.Rows[i]["Característica 3"].ToString() : string.Empty;
 
 newRow["Característica 4"] = precios_inventario.Rows[i]["Característica 4"] != null ?
                               precios_inventario.Rows[i]["Característica 4"].ToString() : string.Empty;
 
 newRow["Característica 5"] = precios_inventario.Rows[i]["Característica 5"] != null ?
                               precios_inventario.Rows[i]["Característica 5"].ToString() : string.Empty;
 
 newRow["Característica 6"] = precios_inventario.Rows[i]["Característica 6"] != null ?
                               precios_inventario.Rows[i]["Característica 6"].ToString() : string.Empty;
 
 newRow["Característica 7"] = precios_inventario.Rows[i]["Característica 7"] != null ?
                               precios_inventario.Rows[i]["Característica 7"].ToString() : string.Empty;
 
 newRow["Característica 8"] = precios_inventario.Rows[i]["Característica 8"] != null ?
                               precios_inventario.Rows[i]["Característica 8"].ToString() : string.Empty;
 
 newRow["Característica 9"] = precios_inventario.Rows[i]["Característica 9"] != null ?
                               precios_inventario.Rows[i]["Característica 9"].ToString() : string.Empty;
 
 newRow["Característica 10"] = precios_inventario.Rows[i]["Característica 10"] != null ?
                                precios_inventario.Rows[i]["Característica 10"].ToString() : string.Empty;
 
 newRow["Facturable"] = precios_inventario.Rows[i]["Facturable"] != null ?
                         precios_inventario.Rows[i]["Facturable"].ToString() : string.Empty;
 
 newRow["Base precio"] = precios_inventario.Rows[i]["Base precio"] != null ?
                          precios_inventario.Rows[i]["Base precio"].ToString() : string.Empty;
 
 newRow["Tipo"] = precios_inventario.Rows[i]["Tipo"] != null ?
                  precios_inventario.Rows[i]["Tipo"].ToString() : string.Empty;
 
 newRow["Pesable"] = precios_inventario.Rows[i]["Pesable"] != null ?
                     precios_inventario.Rows[i]["Pesable"].ToString() : string.Empty;
 
 newRow["Cód. impuesto de IVA Ventas"] = precios_inventario.Rows[i]["Cód. impuesto de IVA Ventas"] != null ?
                                         precios_inventario.Rows[i]["Cód. impuesto de IVA Ventas"].ToString() : string.Empty;
 
 newRow["Cód. impuesto de consumo Ventas"] = precios_inventario.Rows[i]["Cód. impuesto de consumo Ventas"] != null ?
                                             precios_inventario.Rows[i]["Cód. impuesto de consumo Ventas"].ToString() : string.Empty;
 
 newRow["Clase de imp. consumo Compras"] = precios_inventario.Rows[i]["Clase de imp. consumo Compras"] != null ?
                                            precios_inventario.Rows[i]["Clase de imp. consumo Compras"].ToString() : string.Empty;
 
 newRow["Medida Imp. bebidas"] = precios_inventario.Rows[i]["Medida Imp. bebidas"] != null ?
                                  precios_inventario.Rows[i]["Medida Imp. bebidas"].ToString() : string.Empty;
 
 newRow["Gramos Imp. bebidas"] = precios_inventario.Rows[i]["Gramos Imp. bebidas"] != null ?
                                  precios_inventario.Rows[i]["Gramos Imp. bebidas"].ToString() : string.Empty;

    // Agregar la nueva fila a la tabla
    tabla_for_prec_inv.Rows.Add(newRow);
}







