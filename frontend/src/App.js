import './App.css';
import MovieGrid from './Components/MovieGrid';
import MovieDetails from './Components/MovieDetails';
import Search from './Components/Search';
import { ReactComponent as CloseSVG } from './Images/Close.svg';
import { useState, useEffect } from 'react';
import { BASE_URL } from './config.js';

function App() {
    const [results, setResults] = useState([]); // movies currently displayed on screen (popular or search results)
    const [openDetails, setOpenDetails] = useState(false); // whether the details pop-up is open or not
    const [movieDetails, setMovieDetails] = useState({}); // details of selected movie
    const [keyword, setKeyword] = useState(""); // current search keyword
    const [popularLoaded, setPopularLoaded] = useState(false); // whether the user is on the popular movies page or not
    const [prevKeyword, setPrevKeyword] = useState(""); // previous search keyword (used to prevent unnecessary api calls)
    const [page, setPage] = useState(1); // current number of result pages loaded
    const [error, setError] = useState(false); // whether the error message is visible or not
    const [totalPages, setTotalPages] = useState(0);
    const [totalResults, setTotalResults] = useState(0);

    async function fetchPopularMovies() {
        if (popularLoaded) return; // prevent unnecessary api call

        try {
            const response = await fetch(`${BASE_URL}/api/MovieDB/popular?page=1`);
            if (!response.ok) {
                throw new Error('Failed to fetch popular movies');
            }

            const data = await response.json();
            setResults(data.results);
            setKeyword("");
            setPrevKeyword("");
            setPopularLoaded(true);
            setError(false);
            setTotalPages(data.total_Pages);
            setPage(1);
        } catch (error) {
            setError(true);
        }
    }

    async function search() {
        if (!keyword) return;
        if (keyword === prevKeyword) return;

        try {
            const response = await fetch(`${BASE_URL}/api/MovieDB/search?keyword=${encodeURIComponent(keyword)}&page=1`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            setResults(data.results);
            setPrevKeyword(keyword);
            setPage(1);
            setPopularLoaded(false);
            setError(false);
            setTotalPages(data.total_Pages);
            setTotalResults(data.total_Results);
        } catch (error) {
            setError(true);
        }
    }

    async function loadMore() {
        try {
            let response;
            if(popularLoaded === true){
                response = await fetch(`${BASE_URL}/api/MovieDB/popular?page=${page + 1}`);
            }
            else{
                response = await fetch(`${BASE_URL}/api/MovieDB/search?keyword=${encodeURIComponent(keyword)}&page=${page + 1}`);
            }
            if (!response.ok) {
                throw new Error('Failed to fetch more movies');
            }

            const data = await response.json();
            console.log(data)
            setResults([...results, ...data.results]);
            setPage(page + 1);
            setError(false);
        } catch (error) {
            setError(true);
        }
    }

    // fetch popular movies on mount
    useEffect(() => {
        fetchPopularMovies();
    }, []);

    return (
        <div className="page">
            <MovieDetails
                openDetails={openDetails} setOpenDetails={setOpenDetails}
                movieDetails={movieDetails}
            />
            <main className="page-contents">
                {error === true &&
                    <div style={{ display: "flex", justifyContent: "center", zIndex: "10", marginBottom: "16px" }}>
                        <div style={{ position: "fixed", top: "32px" }}>
                            <div id="error-box">
                                <p id="error-msg">
                                    <em>An error has occured, please try again later.</em>
                                </p>
                                <button
                                    id="close-error-btn"
                                    onClick={() => setError(false)}
                                >
                                    <CloseSVG id="close-icon" />
                                </button>
                            </div>
                        </div>
                    </div>
                }
                <div id="top-bar">
                    <Search
                        setResults={setResults}
                        keyword={keyword} setKeyword={setKeyword}
                        setPopularLoaded={setPopularLoaded}
                        prevKeyword={prevKeyword} setPrevKeyword={setPrevKeyword}
                        setPage={setPage}
                        setError={setError}
                        search={search}
                    />
                    <img
                        src="https://www.themoviedb.org/assets/2/v4/logos/v2/blue_long_2-9665a76b1ae401a510ec1e0ca40ddcb3b0cfe45f1d51b77a308fea0845885648.svg"
                        width="180"
                        alt="tmdb logo"
                        style={{ cursor: "pointer" }}
                        onClick={() => fetchPopularMovies()}
                    />
                </div>
                <h2 id="page-title">
                    {popularLoaded === true ?
                        "Popular Movies"
                    : results.length !== 0 ?
                        `Results (${totalResults})`
                    : null}
                </h2>
                <MovieGrid
                    results={results}
                    openDetails={openDetails} setOpenDetails={setOpenDetails}
                    movieDetails={movieDetails} setMovieDetails={setMovieDetails}
                    setError={setError}
                />
                {(totalPages !== page && results.length !== 0) ?
                    <button
                        id="load-more"
                        onClick={() => loadMore()}
                    >
                        Load more
                    </button>
                : null}
            </main>
        </div>
    );
}

export default App;
