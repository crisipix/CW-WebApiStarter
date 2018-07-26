﻿using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Models;
using $safeprojectname$.Repositories;
using $safeprojectname$.Repositories.Dos;

namespace $safeprojectname$.Services.File
{
    public class FileService : IFileService, IDisposable
    {
        private IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly ILog _log;
        
        public FileService(IFileRepository fileRepository,
                           IMapper mapper ,
                           ILog log)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
            _log = log;

        }
        public async Task<FileModel> Upload(FileModel file)
        {
            _log.Debug("File Service Upload");

            var fileDo = _mapper.Map<FileDo>(file);

            fileDo = await _fileRepository.Upload(fileDo);

            return _mapper.Map<FileModel>(fileDo);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FileService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion
    }
}