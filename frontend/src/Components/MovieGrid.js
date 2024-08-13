import MovieCard from "./MovieCard";

function MovieGrid({ results, openDetails, setOpenDetails, movieDetails, setMovieDetails }) {
    return (
        <div id="movie-grid">
            {results.map((movie) => (
                <MovieCard
                    key={movie.id}
                    title={movie.original_Title}
                    year={movie.release_Date}
                    poster={movie.poster_Path}
                    id={movie.id}
                    openDetails={openDetails}
                    setOpenDetails={setOpenDetails}
                    movieDetails={movieDetails}
                    setMovieDetails={setMovieDetails}
                />
            ))}
        </div>
    );
}

export default MovieGrid;