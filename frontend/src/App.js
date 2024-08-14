import './App.css';
import MovieGrid from './Components/MovieGrid';
import MovieDetails from './Components/MovieDetails';
import Search from './Components/Search';
import { useState, useEffect } from 'react';

function App() {
    const [results, setResults] = useState([]);
    const [openDetails, setOpenDetails] = useState(false);
    const [movieDetails, setMovieDetails] = useState({});

    useEffect(() => {
        // Function to fetch the popular movies from your backend
        async function fetchPopularMovies() {
            try {
                const response = await fetch('http://localhost:5259/api/MovieDB/popular?page=1');
                if (!response.ok) {
                    throw new Error('Failed to fetch popular movies');
                }
                const data = await response.json();
                setResults(data.results); // Assuming the response contains a `results` array
                console.log(data);
            } catch (error) {
                console.error('Error fetching popular movies:', error);
            }
        }

        // Call the function when the component mounts
        fetchPopularMovies();
    }, []);

    return (
        <>
        <MovieDetails openDetails={openDetails} setOpenDetails={setOpenDetails} movieDetails={movieDetails} />
        <main className="page-contents">
            <div id="top-bar">
                <Search results={results} setResults={setResults} />
                <img
                    src="https://www.themoviedb.org/assets/2/v4/logos/v2/blue_long_2-9665a76b1ae401a510ec1e0ca40ddcb3b0cfe45f1d51b77a308fea0845885648.svg"
                    width="180"
                    alt="tmdb logo"
                />
            </div>
            <MovieGrid results={results} openDetails={openDetails} setOpenDetails={setOpenDetails} movieDetails={movieDetails} setMovieDetails={setMovieDetails} />
        </main>
        </>
    );
}

export default App;
