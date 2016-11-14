<template>
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
			<div class="container-fluid">
				<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
					<a class="navbar-brand" href="#"><span>Pharma</span>CRM</a>
					<ul class="user-menu">
						<li class="dropdown pull-right">
							<a href="#" class="dropdown-toggle" data-toggle="dropdown">Donald Trump <span class="caret"></span></a>
							<ul class="dropdown-menu" role="menu">
								<li><a href="#">Logout</a></li>
							</ul>
						</li>
					</ul>
				</div>

			</div>
			<!-- /.container-fluid -->
		</nav>

		<div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
			<form role="search">
				<div class="form-group">
					<input type="text" class="form-control" placeholder="Search">
				</div>
			</form>
			<ul class="nav menu">
				<li class="active"><a href="index.html">Dashboard</a></li>
				<li>
					<a href="/customers">Customers</a>
				</li>
				<li><a href="/leads">Leads</a></li>
				<li><a href="/activities">Activities</a></li>
				<li><a href="/salesorders">Sales Orders</a></li>
			</ul>

		</div>
		<!--/.sidebar-->

		<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
			<div class="row">
				<ol class="breadcrumb">
					<li><a href="#"><i class="fa fa-home" aria-hidden="true"></i></a></li>
					<li class="active">Donald Trump</li>
				</ol>
			</div>
			<!--/.row-->

			<div class="row">
				<div class="col-lg-12">
					<h1 class="page-header">Dashboard</h1>
				</div>
			</div>
			<!--/.row-->

			<div class="row">
				<div class="col-lg-4">
					<div class="panel panel-default">
						<div class="panel-heading">Activities</div>
						<div class="panel-body">
						</div>
					</div>
				</div>

				<div class="col-lg-8">
					<div class="panel panel-default">
						<div class="panel-heading">Route</div>
						<div class="panel-body">
						</div>
					</div>
				</div>
			</div>
			<!--/.row-->


			<div class="row">
				<div class="col-md-4">
					<div class="panel panel-default">
						<div class="panel-heading">Data Picker</div>
						<div class="panel-body">
						</div>
					</div>
				</div>

				<div class="col-md-8">
					<div class="panel panel-default">
						<div class="panel-heading">Leads</div>
						<div class="panel-body">
						</div>
					</div>
				</div>
			</div>

			<div class="row">
				<div class="col-lg-12">
					<h1 class="page-header">KPI</h1>
				</div>
			</div>

		</div>
</template>