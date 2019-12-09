<%@ Page Title="Explore Kansas || Home" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectVer1Steven.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>New to Explore Kansas?</h2>
    <p>
        Click the &quot;Create Account&quot; button below to create an account
    </p>
    <p>
        <asp:Button ID="btnCreateAccountDEFAULT" runat="server" class="btn btn-dark" OnClick="Button1_Click" Text="Create Account" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">

        </asp:ScriptManager>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Watch me fade" />

     

    </p>
<ajaxToolkit:AnimationExtender ID="ae" runat="server" TargetControlID="Button1">
 <Animations>
 <OnClick>
 <FadeOut Duration="5" Fps="24" />
 </OnClick>
 </Animations>
</ajaxToolkit:AnimationExtender>

    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel" data-interval="5000">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>

  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src="SVSBSpring_072_41407ec5-d451-49c0-b2f3-6539f727b51c.jpg"" alt="First slide">
        <div class="carousel-caption d-none d-md-block">
    <h5>Travel Kansas</h5>
    <p>This site has fun things to explore while you are in the great state of Kansas</p>
  </div>


    </div>
            <div class="carousel-item">
      <img class="d-block w-100" src="2a9d3b7d37d0431ab597a892bcf6aa2e.jpg"" alt="Third slide">
             <div class="carousel-caption d-none d-md-block">
    <h5>CityData for Kansas</h5>
    <p>This is a site that has information regarding population and other important numbers about the state.</p>
  </div>
    </div>


    <div class="carousel-item">
      <img class="d-block w-100" src="DSC_2714_f25b17f7-570a-41c3-9ab2-2c82af95c44e.jpg"" alt="Second slide">
             <div class="carousel-caption d-none d-md-block">
    <h5>Kansas.gov</h5>
    <p>This is the government site for Kansas, which include all the information about the state including, government, education, residential, and different business within the state. </p>
  </div>
    </div>


    <div class="carousel-item">
      <img class="d-block w-100" src="8f221e5f48334227bc54d2eb82d875c0.jpg"" alt="Third slide">
             <div class="carousel-caption d-none d-md-block">
    <h5>State of Kansas commerce</h5>
    <p>This is the commerce site for Kansas this site includes different business and a few of the main attractions within the state.</p>
  </div>
    </div>

      


        <div class="carousel-item">
      <img class="d-block w-100" src="_DSC4227_9bc97180-a6e3-4908-a3d9-e9791b2c546e.jpg"" alt="Third slide">
             <div class="carousel-caption d-none d-md-block">
    <h5>PlanetWare</h5>
    <p>This is a list of the 12 most popular attractions to visit in Kansas.</p>
  </div>
    </div>


  
      </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

</asp:Content>
