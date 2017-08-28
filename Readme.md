
<h1>API Viewer</h1>
<a href="http://www.dewlife.me">Live Example</a>

<i>This application was created for the code challenge listed below</i>

This application allows the user to view data from various APIs.  

I didn't want to create the application tied to one API so I created the project with the 
thought in mind that it would reference many APIs and give the user the ability to 
select which API they wanted to reference.  So the user would have a category of APIs to choose from.
That would then filter the next drop down list to the APIs in that category.  Once that api is selected, 
the results would follow in the list box.  You can also use the text box filter the results to the closest
match typed.  

<h3>ApiViewer.Standard</h3>
The main project is the ApiViewer.Standard which was created with .Net Standard 2.0 and the only dependency being Newtonsoft.JSON. 
I have chosen this as it will work as a library across many technologies (.net core, .net, xamarin, etc).
This project houses all the APIs and Models.  It also utilizes the Factory Pattern to grant the ability to select the API at 
runtime.  There are various methods that use reflection to get all categories and api names for that item type so there is no 
registration required to build a list of api names or categories.  All the models implement an interface so the caller does not 
need to know the specifics of each class.  All APIs inherit from an abstract API class that houses some basic methods as to reduce 
code duplication.  The APIs and API Factory have unit tests written contained in the ApiViewer.Standard.Tests project.

<h3>ApiViewer.Core.Web</h3>
ApiViewer.Core.Web is created using .Net Core 2.0 so it can be run on any platform (Windows, Linux, Docker, etc).  I chose to use this
project type as .Net core is starting to become pretty mature and has an outstanding performance gain compared to that of even Node!
The index page starts registering some custom js events.  These are used to fire off the next call to the server as one call ends.
So if you pick a category, it will then clear the api drop down and call the server via ajax to get the values for the API drop down 
and fill it.  Once filled, it will fire off the event stating that it is loaded.  That will trigger an event listener that will load 
the listbox for the results of the API selected.  The logic for all these calls are located in the wwwroot/js/logic.js file.  

<h3>ApiViewer.WinForms</h3>
This project was used for my initial testing of the ApiViewer.Standard project.  It does everything the Core.Web project 
can do with the exception of the textbox that filters the results.  As the code challenge called for a responsive web site 
and for a POC, I didn't think it was critical to polish this app.

<h3>ApiViewer.Xamarin and ApiViewer.Xamarin.Android</h3>
This project is mainly to show the reasoning why you would use a .Net Standard library to put all the logic into as you can reference 
it even here.  I added some Pickers for categories and APIs just as in the previous project along with a ListView to view the results.  
This app is pretty basic and does currently have an issue freezing up when it is calling the APIs.  This is caused by the methods 
being called synchronously and not async.  Considering this project went a bit above and beyond the scope of this code challenge, 
I decided to end it here with the basic working example that can be served as a POC.

<br />&nbsp;
<br />&nbsp;
<hr />
<br />&nbsp;
<br />&nbsp;

<div class=WordSection1>

<p class=MsoTitle><span style='font-size:20.0pt;mso-bidi-font-size:26.0pt;
line-height:115%'>Full Stack Engineer<o:p></o:p></span></p>

<div style='mso-element:para-border-div;border:solid #01244A 3.0pt;padding:
0in 0in 0in 0in;background:#01244A'>

<h1>Description</h1>

</div>

<p class=MsoNormal>You’ll be working with a cross-functional engineering team
to deliver <span class=SpellE>PoC’s</span> and experiments; you’ll be the lead
engineer. To demonstrate excellence in modern development tools and frameworks,
we ask that you complete the following challenge. Please use this test to show
off your skill set and what you can bring to the team. You will be critiqued on
your quality, completeness, creativity, and technologies. If we proceed forward
in the interviewing process, you will be asked to walk through your code.
Choose <u>modern</u> technologies that exercise the breadth of approach and
ones that you’re comfortable developing with.</p>

<p class=MsoNormal>When you have completed the following challenge, place your
code in a code repository, ex. <span class=SpellE>github</span>, bitbucket, <span
class=SpellE>dropbox</span>, etc.</p>

<div style='mso-element:para-border-div;border:solid #01244A 3.0pt;padding:
0in 0in 0in 0in;background:#01244A'>

<h1>Mission/Challenge</h1>

</div>

<p class=MsoNoSpacing>Create a responsive (phone, tablet, desktop) web
application that allows the user to quick filter a list of things. The top of
the page will have a search input field and then below that a list of things in
response to the filter. The things should be sorted alphabetically. The things could
be anything, but should be AJAX pulled from a backend service that you write
and should ultimately be pulled from an open public API.</p>

<p class=MsoNoSpacing>Here’s an example list of <span class=GramE>API’s</span>
curated on GitHub, <a href="https://github.com/toddmotto/public-apis">https://github.com/toddmotto/public-apis</a>
but feel free to use any public API you wish.</p>

<p class=MsoNoSpacing><o:p>&nbsp;</o:p></p>

<p class=MsoNoSpacing><o:p>&nbsp;</o:p></p>

</div>
