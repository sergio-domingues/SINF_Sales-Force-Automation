using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS900;
using Interop.StdPlatBS900;
using Interop.StdBE900;
using Interop.GcpBE900;
using Interop.CrmBE900;
using ADODB;

namespace PharmaCRM.Lib_Primavera
{
    public class PriIntegration
    {
        #region Vendedor


        public static List<Model.Vendedor> ListaVendedores()
        {

            StdBELista objList;
            List<Model.Vendedor> listVendedores = new List<Model.Vendedor>();
            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT Vendedor, Nome FROM vendedores");
                while (!objList.NoFim())
                {
                    Model.Vendedor vendedor = new Model.Vendedor();
                    vendedor.cod = objList.Valor("Vendedor");
                    vendedor.nome = objList.Valor("Nome");
                    listVendedores.Add(vendedor);

                    objList.Seguinte();
                }
                return listVendedores;
            }
            else
                return null; // Erro
        }

        public static Lib_Primavera.Model.Vendedor GetVendedor(string id)
        {
            StdBELista objVen = new StdBELista();


            Model.Vendedor myVend = new Model.Vendedor();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Vendedores.Existe(id) == true)
                {
                    objVen = PriEngine.Engine.Consulta("SELECT Vendedor, Nome FROM vendedores WHERE Vendedor = " + "\'" + id + "\'");
                    Model.Vendedor vendedor = new Model.Vendedor();
                    vendedor.cod = objVen.Valor("Vendedor");
                    vendedor.nome = objVen.Valor("Nome");

                    return vendedor;
                }
                else
                {
                    return null;
                }
            }
            else
                return null; // Erro

        }

        public static List<Model.Atividade> GetVendedorAtividades(string vendedorID, string dataInicio, string dataFim)
        {
            StdBELista objList;

            List<Model.Atividade> listTarefas = new List<Model.Atividade>();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Tarefas.* FROM Tarefas, CabecOportunidadesVenda WHERE Vendedor = " + "\'" + vendedorID + "\'"
                        + " AND IdCabecOVenda = CabecOportunidadesVenda.ID"
                        + " AND DataInicio >= \'" + dataInicio + "\'"
                        + " AND DataFim <= \'" + dataFim + "\'"
                    );


                while (!objList.NoFim())
                {
                    Model.Atividade atividade = new Model.Atividade();
                    atividade.id = objList.Valor("Id");
                    atividade.idTipoAtividade = objList.Valor("IdTipoActividade");
                    atividade.estado = objList.Valor("Estado");
                    atividade.descricao = objList.Valor("Descricao");
                    atividade.dataInicio = objList.Valor("DataInicio");
                    atividade.dataFim = objList.Valor("DataFim");
                    atividade.local = objList.Valor("LocalRealizacao");
                    atividade.vendedor = vendedorID;
                    atividade.idCabecalhoOportunidadeVenda = objList.Valor("IDCabecOVenda");
                    
                    listTarefas.Add(atividade);
                    objList.Seguinte();
                }
                return listTarefas;
            }
            else
                return null;
        }

        #endregion Vendedor;

        # region Cliente

        public static List<Model.Cliente> ListaClientes()
        {


            StdBELista objList;

            List<Model.Cliente> listClientes = new List<Model.Cliente>();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Cliente, Nome, Moeda, NumContrib as NumContribuinte, Fac_Mor AS campo_exemplo FROM  CLIENTES");


                while (!objList.NoFim())
                {
                    listClientes.Add(new Model.Cliente
                    {
                        CodCliente = objList.Valor("Cliente"),
                        Nome = objList.Valor("Nome"),
                        NumContribuinte = objList.Valor("NumContribuinte"),
                        Morada = objList.Valor("campo_exemplo")
                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Cliente GetCliente(string codCliente)
        {


            GcpBECliente objCli = new GcpBECliente();


            Model.Cliente myCli = new Model.Cliente();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == true)
                {
                    objCli = PriEngine.Engine.Comercial.Clientes.Edita(codCliente);
                    myCli.CodCliente = objCli.get_Cliente();
                    myCli.Nome = objCli.get_Nome();
                    myCli.NumContribuinte = objCli.get_NumContribuinte();
                    myCli.Morada = objCli.get_Morada();
                    return myCli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.RespostaErro UpdCliente(Lib_Primavera.Model.Cliente cliente)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();


            GcpBECliente objCli = new GcpBECliente();

            try
            {

                if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
                {

                    if (PriEngine.Engine.Comercial.Clientes.Existe(cliente.CodCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        objCli = PriEngine.Engine.Comercial.Clientes.Edita(cliente.CodCliente);
                        objCli.set_EmModoEdicao(true);

                        objCli.set_Nome(cliente.Nome);
                        objCli.set_NumContribuinte(cliente.NumContribuinte);
                        objCli.set_Morada(cliente.Morada);

                        PriEngine.Engine.Comercial.Clientes.Actualiza(objCli);

                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static Lib_Primavera.Model.RespostaErro DelCliente(string codCliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBECliente objCli = new GcpBECliente();


            try
            {

                if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
                {
                    if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        PriEngine.Engine.Comercial.Clientes.Remove(codCliente);
                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }

                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }



        public static Lib_Primavera.Model.RespostaErro InsereClienteObj(Model.Cliente cli)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();


            GcpBECliente myCli = new GcpBECliente();

            try
            {
                if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
                {

                    myCli.set_Cliente(cli.CodCliente);
                    myCli.set_Nome(cli.Nome);
                    myCli.set_NumContribuinte(cli.NumContribuinte);
                    myCli.set_Morada(cli.Morada);

                    PriEngine.Engine.Comercial.Clientes.Actualiza(myCli);

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }


        }



        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------


        #region Artigo

        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {

            GcpBEArtigo objArtigo = new GcpBEArtigo();
            Model.Artigo myArt = new Model.Artigo();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {

                StdBELista objListCab;

                objListCab = PriEngine.Engine.Consulta("SELECT Artigo.Artigo, Descricao, STKActual, PCUltimo, PCMedio, Iva, PrazoEntrega, PVP1, PVP2, PVP3, PVP4, PVP5, PVP6 "
                    + "FROM Artigo, ArtigoMoeda WHERE Artigo.Artigo = ArtigoMoeda.Artigo AND Artigo.Artigo = '" + codArtigo + "'");

                if (objListCab.NoFim())
                {
                    return null;
                }

                Model.Artigo art = new Model.Artigo();
                art.Codigo = objListCab.Valor("Artigo");
                art.Descricao = objListCab.Valor("Descricao");
                art.StockAtual = objListCab.Valor("STKActual");
                art.PrecoUltimo = objListCab.Valor("PCUltimo");
                art.PrecoMedio = objListCab.Valor("PCMedio");
                art.Iva = objListCab.Valor("Iva");
                art.PrazoEntrega = objListCab.Valor("PrazoEntrega");
                art.PVPs = new List<double>();
                art.PVPs.Add(objListCab.Valor("PVP1"));
                art.PVPs.Add(objListCab.Valor("PVP2"));
                art.PVPs.Add(objListCab.Valor("PVP3"));
                art.PVPs.Add(objListCab.Valor("PVP4"));
                art.PVPs.Add(objListCab.Valor("PVP5"));
                art.PVPs.Add(objListCab.Valor("PVP6"));

                return art;
            }
            else
            {
                return null;
            }

        }

        public static List<Model.Artigo> ListaArtigos()
        {
            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {
                StdBELista objListCab;
                Model.Artigo art;
                List<Model.Artigo> listArts = new List<Model.Artigo>();

                objListCab = PriEngine.Engine.Consulta("SELECT Artigo.Artigo, Descricao, STKActual, PCUltimo, PCMedio, Iva, PrazoEntrega, PVP1, PVP2, PVP3, PVP4, PVP5, PVP6 "
                    + "FROM Artigo, ArtigoMoeda WHERE Artigo.Artigo = ArtigoMoeda.Artigo");
                while (!objListCab.NoFim())
                {
                    art = new Model.Artigo();
                    art.Codigo = objListCab.Valor("Artigo");
                    art.Descricao = objListCab.Valor("Descricao");
                    art.StockAtual = objListCab.Valor("STKActual");
                    art.PrecoUltimo = objListCab.Valor("PCUltimo");
                    art.PrecoMedio = objListCab.Valor("PCMedio");
                    art.Iva = objListCab.Valor("Iva");
                    art.PrazoEntrega = objListCab.Valor("PrazoEntrega");
                    art.PVPs = new List<double>();
                    art.PVPs.Add(objListCab.Valor("PVP1"));
                    art.PVPs.Add(objListCab.Valor("PVP2"));
                    art.PVPs.Add(objListCab.Valor("PVP3"));
                    art.PVPs.Add(objListCab.Valor("PVP4"));
                    art.PVPs.Add(objListCab.Valor("PVP5"));
                    art.PVPs.Add(objListCab.Valor("PVP6"));

                    listArts.Add(art);

                    objListCab.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }

        public static Lib_Primavera.Model.ArtigoResumo GetArtigoResumo(string codArtigo)
        {

            GcpBEArtigo objArtigo = new GcpBEArtigo();
            Model.ArtigoResumo myArt = new Model.ArtigoResumo();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == false)
                {
                    return null;
                }
                else
                {
                    objArtigo = PriEngine.Engine.Comercial.Artigos.Edita(codArtigo);
                    myArt.Codigo = objArtigo.get_Artigo();
                    myArt.Descricao = objArtigo.get_Descricao();

                    return myArt;
                }

            }
            else
            {
                return null;
            }

        }

        public static List<Model.ArtigoResumo> ListaArtigosResumo()
        {

            StdBELista objList;

            Model.ArtigoResumo art = new Model.ArtigoResumo();
            List<Model.ArtigoResumo> listArts = new List<Model.ArtigoResumo>();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                while (!objList.NoFim())
                {
                    art = new Model.ArtigoResumo();
                    art.Codigo = objList.Valor("artigo");
                    art.Descricao = objList.Valor("descricao");

                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }

        #endregion Artigo



        #region DocCompra


        public static List<Model.DocCompra> VGR_List()
        {

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindc = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindc = new List<Model.LinhaDocCompra>();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras where TipoDoc='VGR'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }


        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();


            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            Interop.GcpBE900.PreencheRelacaoCompras rl = new Interop.GcpBE900.PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myGR.set_Entidade(dc.Entidade);
                    myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Serie(dc.Serie);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dc.LinhasDoc;
                    //PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR,rl);
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.Quantidade, lin.Armazem, "", lin.PrecoUnitario, lin.Desconto);
                    }


                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        #endregion DocCompra


        #region DocsVenda

        public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();

            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();

            Interop.GcpBE900.PreencheRelacaoVendas rl = new Interop.GcpBE900.PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();

            try
            {
                if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    //PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                    // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    //PriEngine.Engine.Comercial.Vendas.Edita Actualiza(myEnc, "Teste");
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }



        public static List<Model.DocVenda> Encomendas_List()
        {

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }




        public static Model.DocVenda Encomenda_Get(string numdoc)
        {


            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {


                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL' and NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocVenda();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

        #endregion DocsVenda

        # region Atividade

        public static Model.Atividade GetAtividade(string id)
        {

            CrmBEActividade atividade = new CrmBEActividade();
            Model.Atividade model_actividade;

            /*  if (PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
              {*/

            if (PriEngine.Engine.Comercial.Artigos.Existe(id) == false)
            {
                return null;
            }
            else
            {
                atividade = PriEngine.Engine.CRM.Actividades.Edita(id);
                model_actividade = new Model.Atividade();

                model_actividade.descricao = atividade.get_Descricao();
                model_actividade.idTipoAtividade = atividade.get_IDTipoActividade();
                model_actividade.vendedor = atividade.get_CriadoPor();
                model_actividade.local = atividade.get_LocalRealizacao();
                model_actividade.dataInicio = atividade.get_DataInicio();
                model_actividade.dataFim = atividade.get_DataFim();

                return model_actividade;
            }

            //}


            return null;
        }


        #endregion Actividade;   // -----------------------------  END   Actividade    -----------------------


    }
}