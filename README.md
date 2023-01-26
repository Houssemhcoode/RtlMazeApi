# RtlMazeApiScrapper
MazeApii Scrapper Exercice impl
TvMaze Scraper
# Background
For a new metadata ingester we need a service that provides the cast of all the tv shows in the
TVMaze database, so we can enrich our metadata system with this information. The TVMaze
database provides a public REST API that you can query for this data.
http://www.tvmaze.com/api
This API requires no authentication, but it is rate limited, so keep that in mind.
# Exercice
We want you to create an application that:
1. scrapes the TVMaze API for show and cast information;
2. persists the data in storage;
3. provides the scraped data using a REST API.
We want the REST API to satisfy the following business requirements.
1. It should provide a paginated list of all tv shows containing the id of the TV show and a list of
all the cast that are playing in that TV show.
2. The list of the cast must be ordered by birthday descending.
The REST API should provide a JSON response when a call to a HTTP endpoint is made (it's up to you
what URI).
