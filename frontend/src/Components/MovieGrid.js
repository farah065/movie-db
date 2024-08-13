import MovieCard from "./MovieCard";

function MovieGrid( {results, setResults} ) {
    return (
        <div id="movie-grid">
            {results.map((movie) => (
                <MovieCard key={movie.id} title={movie.original_Title} year={movie.release_Date} poster={movie.poster_Path} />))}
        </div>
    );
}

export default MovieGrid;