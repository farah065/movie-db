function MovieCard(props) {
    const posterPath = props.poster === null ? "https://via.placeholder.com/180x267" : props.poster;

    const extractYear = (dateString) => {
        const date = new Date(dateString);
        return date.getFullYear();
    };

    return (
        <div className="movie-card" id={props.key}>
            <img src={`https://image.tmdb.org/t/p/original/${posterPath}`} alt="Movie Poster" />
            <h3 id="movie-title">{props.title}</h3>
            <p id="movie-year">({extractYear(props.year)})</p>
        </div>
    );
}

export default MovieCard;