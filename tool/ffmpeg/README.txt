FFmpeg 64-bit static Windows build from www.gyan.dev

Version: 2024-09-05-git-3d0d0f68d5-full_build-www.gyan.dev

License: GPL v3

Source Code: https://github.com/FFmpeg/FFmpeg/commit/3d0d0f68d5

External Assets
frei0r plugins:   https://www.gyan.dev/ffmpeg/builds/ffmpeg-frei0r-plugins
lensfun database: https://www.gyan.dev/ffmpeg/builds/ffmpeg-lensfun-db

git-full build configuration: 

ARCH                      x86 (generic)
big-endian                no
runtime cpu detection     yes
standalone assembly       yes
x86 assembler             nasm
MMX enabled               yes
MMXEXT enabled            yes
3DNow! enabled            yes
3DNow! extended enabled   yes
SSE enabled               yes
SSSE3 enabled             yes
AESNI enabled             yes
AVX enabled               yes
AVX2 enabled              yes
AVX-512 enabled           yes
AVX-512ICL enabled        yes
XOP enabled               yes
FMA3 enabled              yes
FMA4 enabled              yes
i686 features enabled     yes
CMOV is fast              yes
EBX available             yes
EBP available             yes
debug symbols             yes
strip symbols             yes
optimize for size         no
optimizations             yes
static                    yes
shared                    no
postprocessing support    yes
network support           yes
threading support         pthreads
safe bitstream reader     yes
texi2html enabled         no
perl enabled              yes
pod2man enabled           yes
makeinfo enabled          yes
makeinfo supports HTML    yes
xmllint enabled           yes

External libraries:
avisynth                libharfbuzz             libsvtav1
bzlib                   libilbc                 libtheora
chromaprint             libjxl                  libtwolame
frei0r                  liblensfun              libuavs3d
gmp                     libmodplug              libvidstab
gnutls                  libmp3lame              libvmaf
iconv                   libmysofa               libvo_amrwbenc
ladspa                  libopencore_amrnb       libvorbis
libaom                  libopencore_amrwb       libvpx
libaribb24              libopenjpeg             libvvenc
libaribcaption          libopenmpt              libwebp
libass                  libopus                 libx264
libbluray               libplacebo              libx265
libbs2b                 libqrencode             libxavs2
libcaca                 libquirc                libxevd
libcdio                 librav1e                libxeve
libcodec2               librist                 libxml2
libdav1d                librubberband           libxvid
libdavs2                libshaderc              libzimg
libflite                libshine                libzmq
libfontconfig           libsnappy               libzvbi
libfreetype             libsoxr                 lzma
libfribidi              libspeex                mediafoundation
libgme                  libsrt                  sdl2
libgsm                  libssh                  zlib

External libraries providing hardware acceleration:
amf                     d3d12va                 nvdec
cuda                    dxva2                   nvenc
cuda_llvm               ffnvcodec               opencl
cuvid                   libmfx                  vaapi
d3d11va                 libvpl                  vulkan

Libraries:
avcodec                 avformat                swresample
avdevice                avutil                  swscale
avfilter                postproc

Programs:
ffmpeg                  ffplay                  ffprobe

Enabled decoders:
aac                     g723_1                  pdv
aac_fixed               g729                    pfm
aac_latm                gdv                     pgm
aasc                    gem                     pgmyuv
ac3                     gif                     pgssub
ac3_fixed               gremlin_dpcm            pgx
acelp_kelvin            gsm                     phm
adpcm_4xm               gsm_ms                  photocd
adpcm_adx               h261                    pictor
adpcm_afc               h263                    pixlet
adpcm_agm               h263i                   pjs
adpcm_aica              h263p                   png
adpcm_argo              h264                    ppm
adpcm_ct                h264_cuvid              prores
adpcm_dtk               h264_qsv                prosumer
adpcm_ea                hap                     psd
adpcm_ea_maxis_xa       hca                     ptx
adpcm_ea_r1             hcom                    qcelp
adpcm_ea_r2             hdr                     qdm2
adpcm_ea_r3             hevc                    qdmc
adpcm_ea_xas            hevc_cuvid              qdraw
adpcm_g722              hevc_qsv                qoa
adpcm_g726              hnm4_video              qoi
adpcm_g726le            hq_hqa                  qpeg
adpcm_ima_acorn         hqx                     qtrle
adpcm_ima_alp           huffyuv                 r10k
adpcm_ima_amv           hymt                    r210
adpcm_ima_apc           iac                     ra_144
adpcm_ima_apm           idcin                   ra_288
adpcm_ima_cunning       idf                     ralf
adpcm_ima_dat4          iff_ilbm                rasc
adpcm_ima_dk3           ilbc                    rawvideo
adpcm_ima_dk4           imc                     realtext
adpcm_ima_ea_eacs       imm4                    rka
adpcm_ima_ea_sead       imm5                    rl2
adpcm_ima_iss           indeo2                  roq
adpcm_ima_moflex        indeo3                  roq_dpcm
adpcm_ima_mtf           indeo4                  rpza
adpcm_ima_oki           indeo5                  rscc
adpcm_ima_qt            interplay_acm           rtv1
adpcm_ima_rad           interplay_dpcm          rv10
adpcm_ima_smjpeg        interplay_video         rv20
adpcm_ima_ssi           ipu                     rv30
adpcm_ima_wav           jacosub                 rv40
adpcm_ima_ws            jpeg2000                s302m
adpcm_ms                jpegls                  sami
adpcm_mtaf              jv                      sanm
adpcm_psx               kgv1                    sbc
adpcm_sbpro_2           kmvc                    scpr
adpcm_sbpro_3           lagarith                screenpresso
adpcm_sbpro_4           lead                    sdx2_dpcm
adpcm_swf               libaom_av1              sga
adpcm_thp               libaribb24              sgi
adpcm_thp_le            libaribcaption          sgirle
adpcm_vima              libcodec2               sheervideo
adpcm_xa                libdav1d                shorten
adpcm_xmd               libdavs2                simbiosis_imx
adpcm_yamaha            libgsm                  sipr
adpcm_zork              libgsm_ms               siren
agm                     libilbc                 smackaud
aic                     libjxl                  smacker
alac                    libopencore_amrnb       smc
alias_pix               libopencore_amrwb       smvjpeg
als                     libopus                 snow
amrnb                   libspeex                sol_dpcm
amrwb                   libuavs3d               sonic
amv                     libvorbis               sp5x
anm                     libvpx_vp8              speedhq
ansi                    libvpx_vp9              speex
anull                   libxevd                 srgc
apac                    libzvbi_teletext        srt
ape                     loco                    ssa
apng                    lscr                    stl
aptx                    m101                    subrip
aptx_hd                 mace3                   subviewer
arbc                    mace6                   subviewer1
argo                    magicyuv                sunrast
ass                     mdec                    svq1
asv1                    media100                svq3
asv2                    metasound               tak
atrac1                  microdvd                targa
atrac3                  mimic                   targa_y216
atrac3al                misc4                   tdsc
atrac3p                 mjpeg                   text
atrac3pal               mjpeg_cuvid             theora
atrac9                  mjpeg_qsv               thp
aura                    mjpegb                  tiertexseqvideo
aura2                   mlp                     tiff
av1                     mmvideo                 tmv
av1_cuvid               mobiclip                truehd
av1_qsv                 motionpixels            truemotion1
avrn                    movtext                 truemotion2
avrp                    mp1                     truemotion2rt
avs                     mp1float                truespeech
avui                    mp2                     tscc
bethsoftvid             mp2float                tscc2
bfi                     mp3                     tta
bink                    mp3adu                  twinvq
binkaudio_dct           mp3adufloat             txd
binkaudio_rdft          mp3float                ulti
bintext                 mp3on4                  utvideo
bitpacked               mp3on4float             v210
bmp                     mpc7                    v210x
bmv_audio               mpc8                    v308
bmv_video               mpeg1_cuvid             v408
bonk                    mpeg1video              v410
brender_pix             mpeg2_cuvid             vb
c93                     mpeg2_qsv               vble
cavs                    mpeg2video              vbn
cbd2_dpcm               mpeg4                   vc1
ccaption                mpeg4_cuvid             vc1_cuvid
cdgraphics              mpegvideo               vc1_qsv
cdtoons                 mpl2                    vc1image
cdxl                    msa1                    vcr1
cfhd                    mscc                    vmdaudio
cinepak                 msmpeg4v1               vmdvideo
clearvideo              msmpeg4v2               vmix
cljr                    msmpeg4v3               vmnc
cllc                    msnsiren                vnull
comfortnoise            msp2                    vorbis
cook                    msrle                   vp3
cpia                    mss1                    vp4
cri                     mss2                    vp5
cscd                    msvideo1                vp6
cyuv                    mszh                    vp6a
dca                     mts2                    vp6f
dds                     mv30                    vp7
derf_dpcm               mvc1                    vp8
dfa                     mvc2                    vp8_cuvid
dfpwm                   mvdv                    vp8_qsv
dirac                   mvha                    vp9
dnxhd                   mwsc                    vp9_cuvid
dolby_e                 mxpeg                   vp9_qsv
dpx                     nellymoser              vplayer
dsd_lsbf                notchlc                 vqa
dsd_lsbf_planar         nuv                     vqc
dsd_msbf                on2avc                  vvc
dsd_msbf_planar         opus                    vvc_qsv
dsicinaudio             osq                     wady_dpcm
dsicinvideo             paf_audio               wavarc
dss_sp                  paf_video               wavpack
dst                     pam                     wbmp
dvaudio                 pbm                     wcmv
dvbsub                  pcm_alaw                webp
dvdsub                  pcm_bluray              webvtt
dvvideo                 pcm_dvd                 wmalossless
dxa                     pcm_f16le               wmapro
dxtory                  pcm_f24le               wmav1
dxv                     pcm_f32be               wmav2
eac3                    pcm_f32le               wmavoice
eacmv                   pcm_f64be               wmv1
eamad                   pcm_f64le               wmv2
eatgq                   pcm_lxf                 wmv3
eatgv                   pcm_mulaw               wmv3image
eatqi                   pcm_s16be               wnv1
eightbps                pcm_s16be_planar        wrapped_avframe
eightsvx_exp            pcm_s16le               ws_snd1
eightsvx_fib            pcm_s16le_planar        xan_dpcm
escape124               pcm_s24be               xan_wc3
escape130               pcm_s24daud             xan_wc4
evrc                    pcm_s24le               xbin
exr                     pcm_s24le_planar        xbm
fastaudio               pcm_s32be               xface
ffv1                    pcm_s32le               xl
ffvhuff                 pcm_s32le_planar        xma1
ffwavesynth             pcm_s64be               xma2
fic                     pcm_s64le               xpm
fits                    pcm_s8                  xsub
flac                    pcm_s8_planar           xwd
flashsv                 pcm_sga                 y41p
flashsv2                pcm_u16be               ylc
flic                    pcm_u16le               yop
flv                     pcm_u24be               yuv4
fmvc                    pcm_u24le               zero12v
fourxm                  pcm_u32be               zerocodec
fraps                   pcm_u32le               zlib
frwu                    pcm_u8                  zmbv
ftr                     pcm_vidc
g2m                     pcx

Enabled encoders:
a64multi                hevc_vaapi              pcm_s8_planar
a64multi5               huffyuv                 pcm_u16be
aac                     jpeg2000                pcm_u16le
aac_mf                  jpegls                  pcm_u24be
ac3                     libaom_av1              pcm_u24le
ac3_fixed               libcodec2               pcm_u32be
ac3_mf                  libgsm                  pcm_u32le
adpcm_adx               libgsm_ms               pcm_u8
adpcm_argo              libilbc                 pcm_vidc
adpcm_g722              libjxl                  pcx
adpcm_g726              libmp3lame              pfm
adpcm_g726le            libopencore_amrnb       pgm
adpcm_ima_alp           libopenjpeg             pgmyuv
adpcm_ima_amv           libopus                 phm
adpcm_ima_apm           librav1e                png
adpcm_ima_qt            libshine                ppm
adpcm_ima_ssi           libspeex                prores
adpcm_ima_wav           libsvtav1               prores_aw
adpcm_ima_ws            libtheora               prores_ks
adpcm_ms                libtwolame              qoi
adpcm_swf               libvo_amrwbenc          qtrle
adpcm_yamaha            libvorbis               r10k
alac                    libvpx_vp8              r210
alias_pix               libvpx_vp9              ra_144
amv                     libvvenc                rawvideo
anull                   libwebp                 roq
apng                    libwebp_anim            roq_dpcm
aptx                    libx264                 rpza
aptx_hd                 libx264rgb              rv10
ass                     libx265                 rv20
asv1                    libxavs2                s302m
asv2                    libxeve                 sbc
av1_amf                 libxvid                 sgi
av1_nvenc               ljpeg                   smc
av1_qsv                 magicyuv                snow
av1_vaapi               mjpeg                   sonic
avrp                    mjpeg_qsv               sonic_ls
avui                    mjpeg_vaapi             speedhq
bitpacked               mlp                     srt
bmp                     movtext                 ssa
cfhd                    mp2                     subrip
cinepak                 mp2fixed                sunrast
cljr                    mp3_mf                  svq1
comfortnoise            mpeg1video              targa
dca                     mpeg2_qsv               text
dfpwm                   mpeg2_vaapi             tiff
dnxhd                   mpeg2video              truehd
dpx                     mpeg4                   tta
dvbsub                  msmpeg4v2               ttml
dvdsub                  msmpeg4v3               utvideo
dvvideo                 msrle                   v210
dxv                     msvideo1                v308
eac3                    nellymoser              v408
exr                     opus                    v410
ffv1                    pam                     vbn
ffvhuff                 pbm                     vc2
fits                    pcm_alaw                vnull
flac                    pcm_bluray              vorbis
flashsv                 pcm_dvd                 vp8_vaapi
flashsv2                pcm_f32be               vp9_qsv
flv                     pcm_f32le               vp9_vaapi
g723_1                  pcm_f64be               wavpack
gif                     pcm_f64le               wbmp
h261                    pcm_mulaw               webvtt
h263                    pcm_s16be               wmav1
h263p                   pcm_s16be_planar        wmav2
h264_amf                pcm_s16le               wmv1
h264_mf                 pcm_s16le_planar        wmv2
h264_nvenc              pcm_s24be               wrapped_avframe
h264_qsv                pcm_s24daud             xbm
h264_vaapi              pcm_s24le               xface
hap                     pcm_s24le_planar        xsub
hdr                     pcm_s32be               xwd
hevc_amf                pcm_s32le               y41p
hevc_d3d12va            pcm_s32le_planar        yuv4
hevc_mf                 pcm_s64be               zlib
hevc_nvenc              pcm_s64le               zmbv
hevc_qsv                pcm_s8

Enabled hwaccels:
av1_d3d11va             hevc_dxva2              vc1_dxva2
av1_d3d11va2            hevc_nvdec              vc1_nvdec
av1_d3d12va             hevc_vaapi              vc1_vaapi
av1_dxva2               hevc_vulkan             vp8_nvdec
av1_nvdec               mjpeg_nvdec             vp8_vaapi
av1_vaapi               mjpeg_vaapi             vp9_d3d11va
av1_vulkan              mpeg1_nvdec             vp9_d3d11va2
h263_vaapi              mpeg2_d3d11va           vp9_d3d12va
h264_d3d11va            mpeg2_d3d11va2          vp9_dxva2
h264_d3d11va2           mpeg2_d3d12va           vp9_nvdec
h264_d3d12va            mpeg2_dxva2             vp9_vaapi
h264_dxva2              mpeg2_nvdec             wmv3_d3d11va
h264_nvdec              mpeg2_vaapi             wmv3_d3d11va2
h264_vaapi              mpeg4_nvdec             wmv3_d3d12va
h264_vulkan             mpeg4_vaapi             wmv3_dxva2
hevc_d3d11va            vc1_d3d11va             wmv3_nvdec
hevc_d3d11va2           vc1_d3d11va2            wmv3_vaapi
hevc_d3d12va            vc1_d3d12va

Enabled parsers:
aac                     dvdsub                  mpegaudio
aac_latm                evc                     mpegvideo
ac3                     flac                    opus
adx                     ftr                     png
amr                     g723_1                  pnm
av1                     g729                    qoi
avs2                    gif                     rv34
avs3                    gsm                     sbc
bmp                     h261                    sipr
cavsvideo               h263                    tak
cook                    h264                    vc1
cri                     hdr                     vorbis
dca                     hevc                    vp3
dirac                   ipu                     vp8
dnxhd                   jpeg2000                vp9
dolby_e                 jpegxl                  vvc
dpx                     misc4                   webp
dvaudio                 mjpeg                   xbm
dvbsub                  mlp                     xma
dvd_nav                 mpeg4video              xwd

Enabled demuxers:
aa                      idf                     pcm_f64le
aac                     iff                     pcm_mulaw
aax                     ifv                     pcm_s16be
ac3                     ilbc                    pcm_s16le
ac4                     image2                  pcm_s24be
ace                     image2_alias_pix        pcm_s24le
acm                     image2_brender_pix      pcm_s32be
act                     image2pipe              pcm_s32le
adf                     image_bmp_pipe          pcm_s8
adp                     image_cri_pipe          pcm_u16be
ads                     image_dds_pipe          pcm_u16le
adx                     image_dpx_pipe          pcm_u24be
aea                     image_exr_pipe          pcm_u24le
afc                     image_gem_pipe          pcm_u32be
aiff                    image_gif_pipe          pcm_u32le
aix                     image_hdr_pipe          pcm_u8
alp                     image_j2k_pipe          pcm_vidc
amr                     image_jpeg_pipe         pdv
amrnb                   image_jpegls_pipe       pjs
amrwb                   image_jpegxl_pipe       pmp
anm                     image_pam_pipe          pp_bnk
apac                    image_pbm_pipe          pva
apc                     image_pcx_pipe          pvf
ape                     image_pfm_pipe          qcp
apm                     image_pgm_pipe          qoa
apng                    image_pgmyuv_pipe       r3d
aptx                    image_pgx_pipe          rawvideo
aptx_hd                 image_phm_pipe          rcwt
aqtitle                 image_photocd_pipe      realtext
argo_asf                image_pictor_pipe       redspark
argo_brp                image_png_pipe          rka
argo_cvg                image_ppm_pipe          rl2
asf                     image_psd_pipe          rm
asf_o                   image_qdraw_pipe        roq
ass                     image_qoi_pipe          rpl
ast                     image_sgi_pipe          rsd
au                      image_sunrast_pipe      rso
av1                     image_svg_pipe          rtp
avi                     image_tiff_pipe         rtsp
avisynth                image_vbn_pipe          s337m
avr                     image_webp_pipe         sami
avs                     image_xbm_pipe          sap
avs2                    image_xpm_pipe          sbc
avs3                    image_xwd_pipe          sbg
bethsoftvid             imf                     scc
bfi                     ingenient               scd
bfstm                   ipmovie                 sdns
bink                    ipu                     sdp
binka                   ircam                   sdr2
bintext                 iss                     sds
bit                     iv8                     sdx
bitpacked               ivf                     segafilm
bmv                     ivr                     ser
boa                     jacosub                 sga
bonk                    jpegxl_anim             shorten
brstm                   jv                      siff
c93                     kux                     simbiosis_imx
caf                     kvag                    sln
cavsvideo               laf                     smacker
cdg                     lc3                     smjpeg
cdxl                    libgme                  smush
cine                    libmodplug              sol
codec2                  libopenmpt              sox
codec2raw               live_flv                spdif
concat                  lmlm4                   srt
dash                    loas                    stl
data                    lrc                     str
daud                    luodat                  subviewer
dcstr                   lvf                     subviewer1
derf                    lxf                     sup
dfa                     m4v                     svag
dfpwm                   matroska                svs
dhav                    mca                     swf
dirac                   mcc                     tak
dnxhd                   mgsts                   tedcaptions
dsf                     microdvd                thp
dsicin                  mjpeg                   threedostr
dss                     mjpeg_2000              tiertexseq
dts                     mlp                     tmv
dtshd                   mlv                     truehd
dv                      mm                      tta
dvbsub                  mmf                     tty
dvbtxt                  mods                    txd
dxa                     moflex                  ty
ea                      mov                     usm
ea_cdata                mp3                     v210
eac3                    mpc                     v210x
epaf                    mpc8                    vag
evc                     mpegps                  vc1
ffmetadata              mpegts                  vc1t
filmstrip               mpegtsraw               vividas
fits                    mpegvideo               vivo
flac                    mpjpeg                  vmd
flic                    mpl2                    vobsub
flv                     mpsub                   voc
fourxm                  msf                     vpk
frm                     msnwc_tcp               vplayer
fsb                     msp                     vqf
fwse                    mtaf                    vvc
g722                    mtv                     w64
g723_1                  musx                    wady
g726                    mv                      wav
g726le                  mvi                     wavarc
g729                    mxf                     wc3
gdv                     mxg                     webm_dash_manifest
genh                    nc                      webvtt
gif                     nistsphere              wsaud
gsm                     nsp                     wsd
gxf                     nsv                     wsvqa
h261                    nut                     wtv
h263                    nuv                     wv
h264                    obu                     wve
hca                     ogg                     xa
hcom                    oma                     xbin
hevc                    osq                     xmd
hls                     paf                     xmv
hnm                     pcm_alaw                xvag
iamf                    pcm_f32be               xwma
ico                     pcm_f32le               yop
idcin                   pcm_f64be               yuv4mpegpipe

Enabled muxers:
a64                     h263                    pcm_s24be
ac3                     h264                    pcm_s24le
ac4                     hash                    pcm_s32be
adts                    hds                     pcm_s32le
adx                     hevc                    pcm_s8
aea                     hls                     pcm_u16be
aiff                    iamf                    pcm_u16le
alp                     ico                     pcm_u24be
amr                     ilbc                    pcm_u24le
amv                     image2                  pcm_u32be
apm                     image2pipe              pcm_u32le
apng                    ipod                    pcm_u8
aptx                    ircam                   pcm_vidc
aptx_hd                 ismv                    psp
argo_asf                ivf                     rawvideo
argo_cvg                jacosub                 rcwt
asf                     kvag                    rm
asf_stream              latm                    roq
ass                     lc3                     rso
ast                     lrc                     rtp
au                      m4v                     rtp_mpegts
avi                     matroska                rtsp
avif                    matroska_audio          sap
avm2                    md5                     sbc
avs2                    microdvd                scc
avs3                    mjpeg                   segafilm
bit                     mkvtimestamp_v2         segment
caf                     mlp                     smjpeg
cavsvideo               mmf                     smoothstreaming
chromaprint             mov                     sox
codec2                  mp2                     spdif
codec2raw               mp3                     spx
crc                     mp4                     srt
dash                    mpeg1system             stream_segment
data                    mpeg1vcd                streamhash
daud                    mpeg1video              sup
dfpwm                   mpeg2dvd                swf
dirac                   mpeg2svcd               tee
dnxhd                   mpeg2video              tg2
dts                     mpeg2vob                tgp
dv                      mpegts                  truehd
eac3                    mpjpeg                  tta
evc                     mxf                     ttml
f4v                     mxf_d10                 uncodedframecrc
ffmetadata              mxf_opatom              vc1
fifo                    null                    vc1t
filmstrip               nut                     voc
fits                    obu                     vvc
flac                    oga                     w64
flv                     ogg                     wav
framecrc                ogv                     webm
framehash               oma                     webm_chunk
framemd5                opus                    webm_dash_manifest
g722                    pcm_alaw                webp
g723_1                  pcm_f32be               webvtt
g726                    pcm_f32le               wsaud
g726le                  pcm_f64be               wtv
gif                     pcm_f64le               wv
gsm                     pcm_mulaw               yuv4mpegpipe
gxf                     pcm_s16be
h261                    pcm_s16le

Enabled protocols:
async                   http                    rtmp
bluray                  httpproxy               rtmpe
cache                   https                   rtmps
concat                  icecast                 rtmpt
concatf                 ipfs_gateway            rtmpte
crypto                  ipns_gateway            rtmpts
data                    librist                 rtp
fd                      libsrt                  srtp
ffrtmpcrypt             libssh                  subfile
ffrtmphttp              libzmq                  tcp
file                    md5                     tee
ftp                     mmsh                    tls
gopher                  mmst                    udp
gophers                 pipe                    udplite
hls                     prompeg

Enabled filters:
a3dscope                ddagrab                 pan
aap                     deband                  perlin
abench                  deblock                 perms
abitscope               decimate                perspective
acompressor             deconvolve              phase
acontrast               dedot                   photosensitivity
acopy                   deesser                 pixdesctest
acrossfade              deflate                 pixelize
acrossover              deflicker               pixscope
acrusher                deinterlace_qsv         pp
acue                    deinterlace_vaapi       pp7
addroi                  dejudder                premultiply
adeclick                delogo                  prewitt
adeclip                 denoise_vaapi           prewitt_opencl
adecorrelate            deshake                 procamp_vaapi
adelay                  deshake_opencl          program_opencl
adenorm                 despill                 pseudocolor
aderivative             detelecine              psnr
adrawgraph              dialoguenhance          pullup
adrc                    dilation                qp
adynamicequalizer       dilation_opencl         qrencode
adynamicsmooth          displace                qrencodesrc
aecho                   doubleweave             quirc
aemphasis               drawbox                 random
aeval                   drawbox_vaapi           readeia608
aevalsrc                drawgraph               readvitc
aexciter                drawgrid                realtime
afade                   drawtext                remap
afdelaysrc              drmeter                 remap_opencl
afftdn                  dynaudnorm              removegrain
afftfilt                earwax                  removelogo
afir                    ebur128                 repeatfields
afireqsrc               edgedetect              replaygain
afirsrc                 elbg                    reverse
aformat                 entropy                 rgbashift
afreqshift              epx                     rgbtestsrc
afwtdn                  eq                      roberts
agate                   equalizer               roberts_opencl
agraphmonitor           erosion                 rotate
ahistogram              erosion_opencl          rubberband
aiir                    estdif                  sab
aintegral               exposure                scale
ainterleave             extractplanes           scale2ref
alatency                extrastereo             scale_cuda
alimiter                fade                    scale_qsv
allpass                 feedback                scale_vaapi
allrgb                  fftdnoiz                scale_vulkan
allyuv                  fftfilt                 scdet
aloop                   field                   scharr
alphaextract            fieldhint               scroll
alphamerge              fieldmatch              segment
amerge                  fieldorder              select
ametadata               fillborders             selectivecolor
amix                    find_rect               sendcmd
amovie                  firequalizer            separatefields
amplify                 flanger                 setdar
amultiply               flip_vulkan             setfield
anequalizer             flite                   setparams
anlmdn                  floodfill               setpts
anlmf                   format                  setrange
anlms                   fps                     setsar
anoisesrc               framepack               settb
anull                   framerate               sharpness_vaapi
anullsink               framestep               shear
anullsrc                freezedetect            showcqt
apad                    freezeframes            showcwt
aperms                  frei0r                  showfreqs
aphasemeter             frei0r_src              showinfo
aphaser                 fspp                    showpalette
aphaseshift             fsync                   showspatial
apsnr                   gblur                   showspectrum
apsyclip                gblur_vulkan            showspectrumpic
apulsator               geq                     showvolume
arealtime               gradfun                 showwaves
aresample               gradients               showwavespic
areverse                graphmonitor            shuffleframes
arls                    grayworld               shufflepixels
arnndn                  greyedge                shuffleplanes
asdr                    guided                  sidechaincompress
asegment                haas                    sidechaingate
aselect                 haldclut                sidedata
asendcmd                haldclutsrc             sierpinski
asetnsamples            hdcd                    signalstats
asetpts                 headphone               signature
asetrate                hflip                   silencedetect
asettb                  hflip_vulkan            silenceremove
ashowinfo               highpass                sinc
asidedata               highshelf               sine
asisdr                  hilbert                 siti
asoftclip               histeq                  smartblur
aspectralstats          histogram               smptebars
asplit                  hqdn3d                  smptehdbars
ass                     hqx                     sobel
astats                  hstack                  sobel_opencl
astreamselect           hstack_qsv              sofalizer
asubboost               hstack_vaapi            spectrumsynth
asubcut                 hsvhold                 speechnorm
asupercut               hsvkey                  split
asuperpass              hue                     spp
asuperstop              huesaturation           ssim
atadenoise              hwdownload              ssim360
atempo                  hwmap                   stereo3d
atilt                   hwupload                stereotools
atrim                   hwupload_cuda           stereowiden
avectorscope            hysteresis              streamselect
avgblur                 identity                subtitles
avgblur_opencl          idet                    super2xsai
avgblur_vulkan          il                      superequalizer
avsynctest              inflate                 surround
axcorrelate             interlace               swaprect
azmq                    interleave              swapuv
backgroundkey           join                    tblend
bandpass                kerndeint               telecine
bandreject              kirsch                  testsrc
bass                    ladspa                  testsrc2
bbox                    lagfun                  thistogram
bench                   latency                 threshold
bilateral               lenscorrection          thumbnail
bilateral_cuda          lensfun                 thumbnail_cuda
biquad                  libplacebo              tile
bitplanenoise           libvmaf                 tiltandshift
blackdetect             life                    tiltshelf
blackframe              limitdiff               tinterlace
blend                   limiter                 tlut2
blend_vulkan            loop                    tmedian
blockdetect             loudnorm                tmidequalizer
blurdetect              lowpass                 tmix
bm3d                    lowshelf                tonemap
boxblur                 lumakey                 tonemap_opencl
boxblur_opencl          lut                     tonemap_vaapi
bs2b                    lut1d                   tpad
bwdif                   lut2                    transpose
bwdif_cuda              lut3d                   transpose_opencl
bwdif_vulkan            lutrgb                  transpose_vaapi
cas                     lutyuv                  transpose_vulkan
ccrepack                mandelbrot              treble
cellauto                maskedclamp             tremolo
channelmap              maskedmax               trim
channelsplit            maskedmerge             unpremultiply
chorus                  maskedmin               unsharp
chromaber_vulkan        maskedthreshold         unsharp_opencl
chromahold              maskfun                 untile
chromakey               mcdeint                 uspp
chromakey_cuda          mcompand                v360
chromanr                median                  vaguedenoiser
chromashift             mergeplanes             varblur
ciescope                mestimate               vectorscope
codecview               metadata                vflip
color                   midequalizer            vflip_vulkan
color_vulkan            minterpolate            vfrdet
colorbalance            mix                     vibrance
colorchannelmixer       monochrome              vibrato
colorchart              morpho                  vidstabdetect
colorcontrast           movie                   vidstabtransform
colorcorrect            mpdecimate              vif
colorhold               mptestsrc               vignette
colorize                msad                    virtualbass
colorkey                multiply                vmafmotion
colorkey_opencl         negate                  volume
colorlevels             nlmeans                 volumedetect
colormap                nlmeans_opencl          vpp_qsv
colormatrix             nlmeans_vulkan          vstack
colorspace              nnedi                   vstack_qsv
colorspace_cuda         noformat                vstack_vaapi
colorspectrum           noise                   w3fdif
colortemperature        normalize               waveform
compand                 null                    weave
compensationdelay       nullsink                xbr
concat                  nullsrc                 xcorrelate
convolution             openclsrc               xfade
convolution_opencl      oscilloscope            xfade_opencl
convolve                overlay                 xfade_vulkan
copy                    overlay_cuda            xmedian
corr                    overlay_opencl          xstack
cover_rect              overlay_qsv             xstack_qsv
crop                    overlay_vaapi           xstack_vaapi
cropdetect              overlay_vulkan          yadif
crossfeed               owdenoise               yadif_cuda
crystalizer             pad                     yaepblur
cue                     pad_opencl              yuvtestsrc
curves                  pad_vaapi               zmq
datascope               pal100bars              zoneplate
dblur                   pal75bars               zoompan
dcshift                 palettegen              zscale
dctdnoiz                paletteuse

Enabled bsfs:
aac_adtstoasc           h264_mp4toannexb        pcm_rechunk
av1_frame_merge         h264_redundant_pps      pgs_frame_merge
av1_frame_split         hapqa_extract           prores_metadata
av1_metadata            hevc_metadata           remove_extradata
chomp                   hevc_mp4toannexb        setts
dca_core                imx_dump_header         showinfo
dovi_rpu                media100_to_mjpegb      text2movsub
dts2pts                 mjpeg2jpeg              trace_headers
dump_extradata          mjpega_dump_header      truehd_core
dv_error_marker         mov2textsub             vp9_metadata
eac3_core               mpeg2_metadata          vp9_raw_reorder
evc_frame_merge         mpeg4_unpack_bframes    vp9_superframe
extract_extradata       noise                   vp9_superframe_split
filter_units            null                    vvc_metadata
h264_metadata           opus_metadata           vvc_mp4toannexb

Enabled indevs:
dshow                   lavfi                   vfwcap
gdigrab                 libcdio

Enabled outdevs:
caca                    sdl2

git-full external libraries' versions: 

AMF v1.4.34-2-ga6fca4a
aom v3.10.0-49-g8536402b3e
aribb24 v1.0.3-5-g5e9be27
aribcaption 1.1.1
AviSynthPlus v3.7.3-70-g2b55ba40
bs2b 3.1.0
chromaprint 1.5.1
codec2 1.2.0-103-gff00a6e2
dav1d 1.4.2-34-gbdef299
davs2 1.7-1-gb41cf11
ffnvcodec n12.2.72.0-1-g9934f17
flite v2.2-55-g6c9f20d
freetype VER-2-13-3
frei0r v2.3.3-3-gcbb507d
fribidi v1.0.15-1-g3826589
gsm 1.0.22
harfbuzz 9.0.0-62-ga141e25c
ladspa-sdk 1.17
lame 3.100
lensfun v0.3.95-1504-gbb988ed0
libass 0.17.3-19-g3a7a9b9
libcdio-paranoia 10.2
libgme 0.6.3
libilbc v3.0.4-346-g6adb26d4a4
libjxl v0.10-snapshot-264-gf28befab
libopencore-amrnb 0.1.6
libopencore-amrwb 0.1.6
libplacebo v7.349.0-9-gefb89342
libsoxr 0.1.3
libssh 0.10.6
libtheora 1.1.1
libwebp v1.4.0-84-g2e81017c
oneVPL 2.12
OpenCL-Headers v2024.05.08-5-gd79beab
openmpt libopenmpt-0.6.18-21-g584c8a7a5
opus v1.5.2-16-g5854a9f7
qrencode 4.1.1
quirc 1.2
rav1e p20240612-5-g7ab0de1
rist 0.2.10
rubberband v1.8.1
SDL prerelease-2.29.2-351-g57f1ea71a
shaderc v2024.1-14-g6d28483
shine 3.1.1
snappy 1.1.10
speex Speex-1.2.1-28-g1de1260
srt v1.5.4-rc.0
SVT-AV1 v2.2.1-29-g85e44db4
twolame 0.4.0
uavs3d v1.1-47-g1fd0491
VAAPI 2.23.0.
vidstab v1.1.1-13-g8dff7ad
vmaf v3.0.0-95-gd95b69e0
vo-amrwbenc 0.1.3
vorbis v1.3.7-10-g84c02369
vpx v1.14.1-357-gfbf63dff1
vulkan-loader v1.3.294-1-g2761c15
vvenc v1.12.0-13-gefb49f4
x264 v0.164.3191
x265 3.6-103-gceea74e6c
xavs2 1.4
xevd 0.5.0
xeve 0.5.1
xvid v1.3.7
zeromq 4.3.5
zimg release-3.0.5-150-g7143181
zvbi v0.2.42-58-ga48ab3a

