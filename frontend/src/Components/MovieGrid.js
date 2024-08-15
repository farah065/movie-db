import MovieCard from "./MovieCard";

function MovieGrid({ results, openDetails, setOpenDetails, movieDetails, setMovieDetails, setError }) {
    // Remove duplicate movies based on their ID
    const uniqueMovies = results.reduce((acc, current) => {
        const isDuplicate = acc.find(movie => movie.id === current.id);
        if (!isDuplicate) {
            acc.push(current);
        }
        return acc;
    }, []);

    return (
        <>
            {uniqueMovies.length === 0 ? (
                <div id="no-results">
                    <h2><em>No results found</em></h2>
                </div>
            ) : (
                <div id="movie-grid">
                    {uniqueMovies.map((movie) => (
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
                            setError={setError}
                        />
                    ))}
                </div>
            )}
        </>
    );
}

export default MovieGrid;