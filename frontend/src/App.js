import './App.css';
import MovieGrid from './Components/MovieGrid';
import MovieDetails from './Components/MovieDetails';
import Search from './Components/Search';
import { useState, useEffect } from 'react';

function App() {
    const [results, setResults] = useState([]);
    const [openDetails, setOpenDetails] = useState(false);
    const [movieDetails, setMovieDetails] = useState({});
    const [keyword, setKeyword] = useState("");
    const [popularLoaded, setPopularLoaded] = useState(false);
    const [prevKeyword, setPrevKeyword] = useState("");
    const [page, setPage] = useState(1);

    async function fetchPopularMovies() {
        if (popularLoaded) return;
        try {
            const response = await fetch("http://localhost:5259/api/MovieDB/popular?page=1");
            if (!response.ok) {
                throw new Error('Failed to fetch popular movies');
            }
            const data = await response.json();
            setResults(data.results);
            setKeyword("");
            setPrevKeyword("");
            setPopularLoaded(true);
            console.log(data);
        } catch (error) {
            console.error('Error fetching popular movies:', error);
        }
    }

    async function loadMore() {
        try {
            const response = await fetch(`http://localhost:5259/api/MovieDB/popular?page=${page + 1}`);
            if (!response.ok) {
                throw new Error('Failed to fetch popular movies');
            }
            const data = await response.json();
            setResults([...results, ...data.results]);
            setPage(page + 1);
            console.log(data);
        } catch (error) {
            console.error('Error fetching popular movies:', error);
        }
    }

    useEffect(() => {
        fetchPopularMovies();
    }, []);

    return (
        <div className="page">
            <MovieDetails openDetails={openDetails} setOpenDetails={setOpenDetails} movieDetails={movieDetails} />
            <main className="page-contents">
                <div id="top-bar">
                    <Search setResults={setResults} keyword={keyword} setKeyword={setKeyword} setPopularLoaded={setPopularLoaded} prevKeyword={prevKeyword} setPrevKeyword={setPrevKeyword} setPage={setPage} />
                    <img
                        src="https://www.themoviedb.org/assets/2/v4/logos/v2/blue_long_2-9665a76b1ae401a510ec1e0ca40ddcb3b0cfe45f1d51b77a308fea0845885648.svg"
                        width="180"
                        alt="tmdb logo"
                        style={{ cursor: "pointer" }}
                        onClick={() => fetchPopularMovies()}
                    />
                </div>
                <MovieGrid results={results} openDetails={openDetails} setOpenDetails={setOpenDetails} movieDetails={movieDetails} setMovieDetails={setMovieDetails} />
                {popularLoaded === true ? <button onClick={() => loadMore()} id="load-more">Load more</button> : null}
            </main>
        </div>
    );
}

export default App;
