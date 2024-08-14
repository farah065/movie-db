function MovieCard(props) {
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
            props.setMovieDetails(data);
            console.log(data);
            props.setOpenDetails(true);
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
        }
    }

    return (
        <div className="card-container" id={props.id}>
            <div className="movie-card" onClick={() => viewDetails(props.id)}>
                <div className="card-img-container">
                    {props.poster && props.poster !== "" ?
                        <img src={`https://image.tmdb.org/t/p/original/${props.poster}`} alt="Movie Poster" />
                        : <div className="img-placeholder">
                            <p style={{color: "#999", fontSize: "20px"}}><em>No Image</em></p>
                        </div>
                    }
                </div>
                <h3 id="movie-title">{props.title}</h3>
                <p id="movie-year">({extractYear(props.year)})</p>
            </div>
        </div>
    );
}

export default MovieCard;