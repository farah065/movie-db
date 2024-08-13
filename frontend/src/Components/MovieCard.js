function MovieCard(props) {
    const posterPath = props.poster === null ? "https://via.placeholder.com/180x267" : props.poster;

    const extractYear = (dateString) => {
        const date = new Date(dateString);
        return date.getFullYear();
    };

    async function viewDetails(id) {
        try {
            const response = await fetch(`http://localhost:5259/api/MovieDB/${id}`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            console.log(data);
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
        }
    }

    return (
        <div className="movie-card" id={props.id} onClick={() => viewDetails(props.id)}>
            <img src={`https://image.tmdb.org/t/p/original/${posterPath}`} alt="Movie Poster" />
            <h3 id="movie-title">{props.title}</h3>
            <p id="movie-year">({extractYear(props.year)})</p>
        </div>
    );
}

export default MovieCard;