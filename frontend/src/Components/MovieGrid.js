import MovieCard from "./MovieCard";

function MovieGrid({ results, openDetails, setOpenDetails, movieDetails, setMovieDetails }) {
    return (
        <>
            {results.length === 0 ?
                <div id="no-results">
                    <h2><em>No results found</em></h2>
                </div>
                :
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
            }
        </>
    );
}

export default MovieGrid;