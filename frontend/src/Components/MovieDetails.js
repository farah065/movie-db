import Dialog from '@mui/material/Dialog';

function MovieDetails({ openDetails, setOpenDetails, movieDetails }) {
    const handleClose = () => setOpenDetails(false);
    const options = { year: 'numeric', month: 'long', day: 'numeric' };

    return (
        <Dialog
            open={openDetails}
            onClose={handleClose}
            PaperProps={{ sx: { borderRadius: "16px" } }}
            sx={{
                "& .MuiDialog-container": {
                    "& .MuiPaper-root": {
                        width: "100%",
                        maxWidth: "700px",
                    },
                },
            }}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
        >
            <div className="detail-container" id="detail-container">
                {movieDetails.poster_Path &&
                    <div className="detail-img-container">
                        <img src={`https://image.tmdb.org/t/p/original/${movieDetails.poster_Path}`} alt="Movie Poster" className="detail-img" />
                    </div>
                }
                <div style={{display: "flex", flexDirection: "column", justifyContent: "space-between", gap: "32ddedpx"}}>
                    <div className="detail-text-container">
                        {movieDetails.original_Title && <h2 id="detail-title">{movieDetails.original_Title}</h2>}
                        {movieDetails.overview && <p id="detail-title">{movieDetails.overview}</p>}
                    </div>
                    <div style={{display: "flex", flexDirection: "column", gap: "16px"}}>
                        {(movieDetails.genres && movieDetails.genres.length !== 0) &&
                            <div>
                                <h5 id="detail-title">Genres</h5>
                                <p>{movieDetails.genres.map(genre => genre.name).join(", ")}</p>
                            </div>
                        }
                        {(movieDetails.production_Companies && movieDetails.production_Companies.length !== 0) &&
                            <div>
                                <h5 id="detail-title">Production Companies</h5>
                                <p>{movieDetails.production_Companies.map(pc => pc.name).join(", ")}</p>
                            </div>
                        }
                        <div style={{display: "flex", gap: "32px"}}>
                            {(movieDetails.release_Date && movieDetails.release_Date !== null) &&
                                <div>
                                    <h5 id="detail-title">Release Date</h5>
                                    <p>{(new Date(movieDetails.release_Date)).toLocaleDateString('en-US', options)}</p>
                                </div>
                            }
                            {(movieDetails.runtime && movieDetails.runtime !== 0) ?
                                <div>
                                    <h5 id="detail-title">Runtime</h5>
                                    <p>{movieDetails.runtime} mins</p>
                                </div>
                                : null
                            }
                            {(movieDetails.original_Language) &&
                                <div>
                                    <h5 id="detail-title">Language</h5>
                                    <p>{movieDetails.original_Language}</p>
                                </div>
                            }
                        </div>
                    </div>
                </div>
            </div>
        </Dialog>
    );
}

export default MovieDetails;